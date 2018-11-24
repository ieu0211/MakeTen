using System;
using System.Linq;
using Application;
using MakeTen.Application;
using MakeTen.Domain.UseCase.Interface;
using MakeTen.Domain.UseCase.Interface.Game;
using MakeTen.Domain.UseCase.Title;
using MakeTen.Presentation.Presenter.Game;
using MakeTen.Presentation.Presenter.Interface.Game;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Zenject;
using Random = UnityEngine.Random;

namespace MakeTen.Domain.UseCase.Game
{
    public interface IGameStateUseCase : IUseCase
    {
    }
    
    public class GameStateUseCase : IGameStateUseCase, IInitializable
    {
        [Inject] private IGamePresenter _gamePresenter { get; }

        private ReactiveProperty<FormulaModel> _formula = new ReactiveProperty<FormulaModel>();
        private int score = 0;
        
        // ほんとうはmodelにする
        private ISubject<Unit> OnCorrectSubject { get; } = new Subject<Unit>();
        private ISubject<Unit> OnIncorrectSubject { get; } = new Subject<Unit>();
        //private ISubject<Unit> TimeUpSubject { get; } = new Subject<Unit>();
        
        public void Initialize()
        {   
            // Timer
            var remainingTime = new ReactiveProperty<float>(Constant.PlayTime);
            
            Observable
                .EveryUpdate()
                .Subscribe(_ => remainingTime.Value -= Time.deltaTime);

            remainingTime
                .Where(x => x >= 0.0f)
                .Subscribe(x => _gamePresenter.RenderTimer(x));

            remainingTime
                .Where(x => x < 0.0f)
                .First()
                .Subscribe(_ => SceneManager.LoadSceneAsync(Constant.SceneName.Result));
            
            // fomula
            // まずはじめに表示
            _formula.Value = FormulaModel.Create();
            // 正解したら変更
            OnCorrectSubject
                .Subscribe(_ =>
                {
                    _formula.Value = FormulaModel.Create();
                });

            // ひょうじ
            _formula
                .Subscribe(x => _gamePresenter.RenderFormula(x));
            
            // operation
            _gamePresenter
                .OnSelectOperation()// マージ？する
                .Subscribe(x =>
                {
                    if (_formula.Value.IsCorrect(x))
                        OnCorrectSubject.OnNext(Unit.Default);
                    else
                        OnIncorrectSubject.OnNext(Unit.Default);
                });

            // Score
            OnCorrectSubject
                .Subscribe(_ =>
                {
                    score++;
                    _gamePresenter.RenderScore(score);
                });
        }
    }

    public class FormulaModel
    {
        public int leftNumber;

        public int rightNumber
        {
            get
            {
                switch (Operation)
                {
                    case Enumerate.Operation.Plus:
                        return 10 - leftNumber;
                    case Enumerate.Operation.Minus:
                        return 10 + leftNumber;
                    case Enumerate.Operation.Multiply:
                        return 10 / leftNumber;
                    case Enumerate.Operation.Divide:
                        return 10 * leftNumber;
                    default:
                        throw new Exception();                    
                }
            }
        }
        
        private Enumerate.Operation Operation;

        public static FormulaModel Create()
        {
            var model = new FormulaModel();

            var random = new System.Random();
            while (true)
            {
                model.leftNumber = Random.Range(1, 1000);
                model.Operation = Enum.GetValues(typeof(Enumerate.Operation)).Cast<Enumerate.Operation>().OrderBy(x => random.Next()).FirstOrDefault();
                if (model.Check())
                    break;
            }
            
            return model;
        }

        public bool IsCorrect(Enumerate.Operation operation)
        {
            return operation == Operation;
        }

        private bool Check()
        {
            if (leftNumber <= 0 || rightNumber <= 0)
            {
                return false;
            }
            
            switch (Operation)
            {
                case Enumerate.Operation.Plus:
                    return leftNumber + rightNumber == 10;
                case Enumerate.Operation.Minus:
                    return leftNumber - rightNumber == 10;
                case Enumerate.Operation.Multiply:
                    return leftNumber * rightNumber == 10;
                case Enumerate.Operation.Divide:
                    return leftNumber / rightNumber == 10;
                default:
                    return false;                    
            }
        }
    }
}