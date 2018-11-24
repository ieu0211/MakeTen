using System;
using DefaultNamespace;
using MakeTen.Domain.UseCase.Interface.Result;
using UniRx;
using Zenject;

namespace Presentation.Presenter.Result
{
    public class ResultPresenter : IResultPresenter
    {
        [Inject] private IResultView resultView;
        [Inject] private IReturnTitleButtonView returnTitleButtonView;
        [Inject] private IRetryButtonView retryButtonView;
        
        public void RenderResult(int score)
        {
            resultView.RenderResult(score);
        }

        public IObservable<Unit> OnNavigateToTitleAsObservable()
        {
            return returnTitleButtonView.OnClickAsObservable();
        }
        
        public IObservable<Unit> OnNavigateToGameAsObservable()
        {
            return retryButtonView.OnClickAsObservable();
        }
    }
}