using MakeTen.Application;
using MakeTen.Domain.UseCase.Interface.Title;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace MakeTen.Domain.UseCase.Title
{
    public interface ITitleUseCase
    {
    }
    
    public sealed class TitleUseCase : ITitleUseCase, IInitializable
    {
        [Inject] private ITitlePresenter titlePresenter { get; }
        
        public void Initialize()
        {
            titlePresenter.OnNavigateToGameAsObservable().Subscribe(_ => NavigateToGame());
        }

        private void NavigateToGame()
        {
            SceneManager.LoadSceneAsync(Constant.SceneName.Game);
        }
    }
}