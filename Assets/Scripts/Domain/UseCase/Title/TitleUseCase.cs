using System;
using MakeTen.Application;
using MakeTen.Application.Manager;
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