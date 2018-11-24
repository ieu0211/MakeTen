using System;
using MakeTen.Domain.UseCase.Interface;
using UniRx;

namespace MakeTen.Domain.UseCase.Interface.Title
{
    public interface ITitlePresenter : IPresenter
    {
        IObservable<Unit> OnNavigateToGameAsObservable();
    }
}