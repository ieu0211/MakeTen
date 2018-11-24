using System;
using Application;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IMinusButtonView : IView
    {
        IObservable<Enumerate.Operation> OnClickAsObservable();
    }
}