using System;
using Application;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IDivideButtonView
    {
        IObservable<Enumerate.Operation> OnClickAsObservable();
    }
}