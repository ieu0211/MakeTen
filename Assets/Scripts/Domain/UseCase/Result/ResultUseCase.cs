using Maketen.Data.Repository.Game;
using MakeTen.Application;
using MakeTen.Domain.Translator.Game;
using MakeTen.Domain.UseCase.Interface;
using MakeTen.Domain.UseCase.Interface.Result;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace Domain.UseCase.Result
{
    public interface IResultUseCase : IUseCase
    {
    }
    
    public sealed class ResultUseCase : IResultUseCase, IInitializable
    {
        [Inject] private IGameResultRepository gameResultRepository { get; }
        [Inject] private IGameResultTranslator gameResultTranslator { get; }
        
        [Inject] private IResultPresenter resultPresenter { get; }
        
        public void Initialize()
        {
            resultPresenter
                .OnNavigateToGameAsObservable()
                .Subscribe(_ => SceneManager.LoadSceneAsync(Constant.SceneName.Game));
            
            resultPresenter
                .OnNavigateToTitleAsObservable()
                .Subscribe(_ => SceneManager.LoadSceneAsync(Constant.SceneName.Title));

            var gameResultEntity = gameResultRepository.Read();
            var gameResultModel = gameResultTranslator.Translate(gameResultEntity);
            
            resultPresenter.RenderResult(gameResultModel.Score.Value);
        }
    }
}