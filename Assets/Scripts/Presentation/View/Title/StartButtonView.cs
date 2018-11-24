using System;
using System.Collections;
using System.Collections.Generic;
using MakeTen.Application.Presentation.Presenter.Interface.Title;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Title
{
    public sealed class StartButtonView : UIBehaviour, IStartButtonView
    {
        public IObservable<Unit> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }
    }
}