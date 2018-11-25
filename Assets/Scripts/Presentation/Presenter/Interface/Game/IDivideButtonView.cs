using System;
using Application;
using MakeTen.Domain.Model.Game;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IDivideButtonView
    {
        IObservable<Enumerate.Operation> OnClickAsObservable();
        void Correct();
        void InCorrect();
    }
}