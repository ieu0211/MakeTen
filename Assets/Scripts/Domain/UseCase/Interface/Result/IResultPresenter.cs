using System;
using UniRx;

namespace MakeTen.Domain.UseCase.Interface.Result
{
    public interface IResultPresenter : IPresenter
    {
        void RenderResult(int score);

        IObservable<Unit> OnNavigateToTitleAsObservable();

        IObservable<Unit> OnNavigateToGameAsObservable();
    }
}