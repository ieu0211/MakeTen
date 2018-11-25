using System;
using UniRx;

namespace MakeTen.Presentation.Presenter.Interface.Title
{
    public interface IStartButtonView : IView
    {
        IObservable<Unit> OnClickAsObservable();
    }
}
