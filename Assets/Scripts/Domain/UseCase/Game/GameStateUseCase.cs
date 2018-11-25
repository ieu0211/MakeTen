using Maketen.Data.Repository.Game;
using MakeTen.Domain.Model.Game;
using MakeTen.Application;
using MakeTen.Domain.Translator.Game;
using MakeTen.Domain.UseCase.Interface;
using MakeTen.Domain.UseCase.Interface.Game;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace MakeTen.Domain.UseCase.Game
{
    public interface IGameStateUseCase : IUseCase
    {
    }
    
    // TODO: UseCaseの粒度を高める
    public sealed class GameStateUseCase : IGameStateUseCase, IInitializable
    {
        [Inject] private IGameStateRepository gameStateRepository { get; }
        [Inject] private IGameStateModelTranslator gameStateModelTranslator { get; }
     
        [Inject] private IGameResultRepository gameResultRepository { get; }
        [Inject] private IGameResultTranslator GameResultTranslator { get; }
        
        [Inject] private IGamePresenter gamePresenter { get; }
        
        public void Initialize()
        {
            var gameStateEntity = gameStateRepository.GetEntity();
            var gameStateModel = gameStateModelTranslator.Translate(gameStateEntity);

            var gameResultEntity = gameResultRepository.GetEntity();
            var gameResultModel = GameResultTranslator.Translate(gameResultEntity);
            
            Observable
                .EveryUpdate()
                .Subscribe(_ => gameStateModel.RemainingTime.Value -= Time.deltaTime);

            gameStateModel
                .RemainingTime
                .Where(x => x >= 0.0f)
                .Subscribe(x => gamePresenter.RenderTimer(x));

            gameStateModel
                .RemainingTime
                .Where(x => x < 0.0f)
                .First()
                .Subscribe(_ => NavigateToResult(gameResultModel));
            
            var currentFormulaModel = new ReactiveProperty<IFormulaModel>(FormulaModelFactory.Create());

            currentFormulaModel
                .Subscribe(x => gamePresenter.RenderFormula(x));
            
            gamePresenter
                .OnSelectOperation()
                .Subscribe(x =>
                {
                    if (currentFormulaModel.Value.IsCorrect(x))
                        gameStateModel.OnCorrectSubject.OnNext(x);
                    else
                        gameStateModel.OnIncorrectSubject.OnNext(x);
                });

            gameStateModel
                .OnCorrectSubject
                .Subscribe(x => gamePresenter.Correct(x));
            
            gameStateModel
                .OnCorrectSubject
                .Subscribe(_ => IncreaseScore(gameResultModel));

            gameResultModel
                .Score
                .Subscribe(x => gamePresenter.RenderScore(x));
            
            gameStateModel
                .OnCorrectSubject
                .Subscribe(_ => currentFormulaModel.Value = FormulaModelFactory.Create());
            
            gameStateModel
                .OnIncorrectSubject
                .Subscribe(x => gamePresenter.Incorrect(x));
        }

        private void NavigateToResult(IGameResultModel gameResultModel)
        {
            var gameResultEntity = GameResultTranslator.Translate(gameResultModel);
            gameResultRepository.Write(gameResultEntity);
                    
            SceneManager.LoadSceneAsync(Constant.SceneName.Result);
        }

        private void IncreaseScore(IGameResultModel gameResultModel)
        {
            gameResultModel.Score.Value++;
        }
    }
}