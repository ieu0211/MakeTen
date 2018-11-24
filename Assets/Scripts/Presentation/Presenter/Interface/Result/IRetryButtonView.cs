using System;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;

namespace DefaultNamespace
{
    public interface IRetryButtonView : IView
    {
        IObservable<Unit> OnClickAsObservable();
    }
}