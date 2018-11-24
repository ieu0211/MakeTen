using System.ComponentModel;
using MakeTen.Application;
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
    
    public class ResultUseCase : IResultUseCase, IInitializable
    {
        [Inject] private IResultPresenter resultPresenter { get; }
        
        public void Initialize()
        {
            resultPresenter
                .OnNavigateToGameAsObservable()
                .Subscribe(_ => SceneManager.LoadSceneAsync(Constant.SceneName.Game));
            
            resultPresenter
                .OnNavigateToTitleAsObservable()
                .Subscribe(_ => SceneManager.LoadSceneAsync(Constant.SceneName.Title));
            
            resultPresenter.RenderResult(999);
        }
    }
}