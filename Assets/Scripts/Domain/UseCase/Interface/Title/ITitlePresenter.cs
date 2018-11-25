using System;
using UniRx;

namespace MakeTen.Domain.UseCase.Interface.Title
{
    public interface ITitlePresenter : IPresenter
    {
        IObservable<Unit> OnNavigateToGameAsObservable();
    }
}