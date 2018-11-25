using System;
using MakeTen.Application.Manager;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.UseCase.Interface.Result;
using UniRx;
using Zenject;

namespace Presentation.Presenter.Result
{
    public sealed class ResultPresenter : IResultPresenter, IInitializable
    {
        [Inject] private SoundManager soundManager { get; }
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
        
        public void Initialize()
        {
            soundManager.PlayResultBgm();
        }
    }
}