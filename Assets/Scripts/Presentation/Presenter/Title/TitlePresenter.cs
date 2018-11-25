using System;
using System.Collections;
using System.Collections.Generic;
using MakeTen.Application.Manager;
using MakeTen.Application.Presentation.Presenter.Interface.Title;
using MakeTen.Domain.UseCase.Interface;
using MakeTen.Domain.UseCase.Interface.Title;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace MakeTen.Presentation.Title
{
    public class TitlePresenter : ITitlePresenter, IInitializable
    {
        [Inject] private SoundManager soundManager { get; }
        [Inject] private IStartButtonView startButtonView { get; }
        
        public IObservable<Unit> OnNavigateToGameAsObservable()
        {
            return startButtonView.OnClickAsObservable();
        }
        
        public void Initialize()
        {
            soundManager.PlayTitleBgm();
        }
    }
}
