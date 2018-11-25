using System;
using MakeTen.Application.Manager;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using Zenject;

namespace MakeTen.Domain.Model.Game
{
    public sealed class RetryButtonView : UIBehaviour, IRetryButtonView, IInitializable
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