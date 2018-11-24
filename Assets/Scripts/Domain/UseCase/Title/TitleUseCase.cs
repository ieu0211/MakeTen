using System;
using MakeTen.Application;
using MakeTen.Application.Presentation.Presenter.Interface.Title;
using MakeTen.Domain.UseCase.Interface.Title;
using TMPro;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace MakeTen.Domain.UseCase.Title
{
    public interface ITitleUseCase
    {
    }
    
    public sealed class TitleUseCase : ITitleUseCase, IInitializable
    {
        [Inject]
        private ITitlePresenter _TitlePresenter { get; }
        
        public void Initialize()
        {
            _TitlePresenter.OnNavigateToGameAsObservable().Subscribe(_ => NavigateToGame());
        }

        private static async UniTask NavigateToGame()
        {
            await SceneManager.LoadSceneAsync(Constant.SceneName.Game);
        }
    }
}