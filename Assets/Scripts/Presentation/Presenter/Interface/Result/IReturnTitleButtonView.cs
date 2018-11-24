using System;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;

namespace DefaultNamespace
{
    public interface IReturnTitleButtonView : IView
    {
        IObservable<Unit> OnClickAsObservable();
    }
}