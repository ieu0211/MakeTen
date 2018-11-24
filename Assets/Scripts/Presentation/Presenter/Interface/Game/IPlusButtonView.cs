using System;
using Application;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IPlusButtonView : IView
    {
        IObservable<Enumerate.Operation> OnClickAsObservable();
    }
}