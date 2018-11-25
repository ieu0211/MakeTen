using System;
using MakeTen.Application.Manager;
using MakeTen.Presentation.Presenter.Interface.Title;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using Zenject;

namespace MakeTen.Presentation.View.Title
{
    public sealed class StartButtonView : UIBehaviour, IStartButtonView, IInitializable
    {
        [Inject] private SoundManager soundManager { get; }
        
        public IObservable<Unit> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }

        public void Initialize()
        {
            OnClickAsObservable().Subscribe(_ => soundManager.PlayPositiveSe());
        }
    }
}