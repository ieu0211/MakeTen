using System;
using MakeTen.Presentation.Presenter.Interface;
using UniRx;

namespace MakeTen.Domain.Model.Game
{
    public interface IReturnTitleButtonView : IView
    {
        IObservable<Unit> OnClickAsObservable();
    }
}