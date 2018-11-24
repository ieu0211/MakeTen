using System;
using System.Collections;
using System.Collections.Generic;
using MakeTen.Application.Presentation.Presenter.Interface.Title;
using MakeTen.Domain.UseCase.Interface;
using MakeTen.Domain.UseCase.Interface.Title;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace MakeTen.Presentation.Title
{
    public class TitlePresenter : ITitlePresenter
    {
        [Inject]
        private IStartButtonView StartButtonView { get; }
        
        public IObservable<Unit> OnNavigateToGameAsObservable()
        {
            return StartButtonView.OnClickAsObservable();
        }
    }
}
