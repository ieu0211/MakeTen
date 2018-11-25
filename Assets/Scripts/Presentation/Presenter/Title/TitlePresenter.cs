using System;
using MakeTen.Application.Manager;
using MakeTen.Domain.UseCase.Interface.Title;
using MakeTen.Presentation.Presenter.Interface.Title;
using UniRx;
using Zenject;

namespace MakeTen.Presentation.Title
{
    public sealed class TitlePresenter : ITitlePresenter, IInitializable
    {
        [Inject] private SoundManager soundManager { get; }
        [Inject] private IStartButtonView startButtonView { get; }
        
        public IObservable<Unit> OnNavigateToGameAsObservable()
        {
            return startButtonView.OnClickAsObservable();
        }
        
        public void Initialize()
        {
            soundManager.PlayTitleBgm();
        }
    }
}
