using System;
using System.Linq;
using Application;
using Maketen.Data.Repository.Game;
using MaketTen.Data.Entity.Game;
using MakeTen.Domain.Model.Game;
using MakeTen.Application;
using MakeTen.Domain.Translator.Game;
using MakeTen.Domain.Translator.Interface;
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
        
        
        
        //[Inject] private IFactory<IFormulaModel> FormulaModelFactory { get; }

        private ReactiveProperty<FormulaModel> _formula = new ReactiveProperty<FormulaModel>();
        //private int score = 0;

        [Inject] private IGameStateRepository gameStateRepository { get; }
        [Inject] private IGameStateTranslator gameStateTranslator { get; }
     
        [Inject] private IGameResultRepository gameResultRepository { get; }
        [Inject] private IGameResultTranslator gameResultTranslator { get; }
        
        [Inject] private IGamePresenter gamePresenter { get; }
        
     

        public void Initialize()
        {
            var gameStateEntity = gameStateRepository.GameStateEntity;
            var gameStateModel = gameStateTranslator.Translate(gameStateEntity);

            var gameResultEntity = gameResultRepository.GameResultEntity;
            var gameResultModel = gameResultTranslator.Translate(gameResultEntity);
            
            Observable
                .EveryUpdate()
                .Subscribe(_ => gameStateModel.RemainingTime.Value -= Time.deltaTime);

            gameStateModel.RemainingTime
                .Where(x => x >= 0.0f)
                .Subscribe(x => gamePresenter.RenderTimer(x));

            gameStateModel.RemainingTime
                .Where(x => x < 0.0f)
                .First()
                .Subscribe(_ => SceneManager.LoadSceneAsync(Constant.SceneName.Result));
            
            // fomula
            // まずはじめに表示
            _formula.Value = FormulaModel.Create();
            // 正解したら変更
            gameStateModel.OnCorrectSubject
                .Subscribe(_ =>
                {
                    _formula.Value = FormulaModel.Create();
                });

            // ひょうじ
            _formula
                .Subscribe(x => gamePresenter.RenderFormula(x));
            
            // operation
            gamePresenter
                .OnSelectOperation()// マージ？する
                .Subscribe(x =>
                {
                    if (_formula.Value.IsCorrect(x))
                        gameStateModel.OnCorrectSubject.OnNext(Unit.Default);
                    else
                        gameStateModel.OnIncorrectSubject.OnNext(Unit.Default);
                });

            // Score
            gameStateModel.OnCorrectSubject
                .Subscribe(_ =>
                {
                    gameResultModel.Score.Value++;
                    gamePresenter.RenderScore(gameResultModel.Score.Value);
                });
        }
    }
}