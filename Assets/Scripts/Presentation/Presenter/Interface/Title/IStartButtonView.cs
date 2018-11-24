using System;
using System.Collections;
using System.Collections.Generic;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;
using UnityEngine;

namespace MakeTen.Application.Presentation.Presenter.Interface.Title
{
    public interface IStartButtonView : IView
    {
        IObservable<Unit> OnClickAsObservable();
    }
}
