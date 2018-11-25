using System;
using Application;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IMultiplyButtonView
    {
        IObservable<Enumerate.Operation> OnClickAsObservable();
        void Correct();
        void InCorrect();
    }
}