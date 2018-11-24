using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace MakeTen.Domain.Model.Game
{
    public class RetryButtonView : UIBehaviour, IRetryButtonView
    {
        public IObservable<Unit> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }
    }
}