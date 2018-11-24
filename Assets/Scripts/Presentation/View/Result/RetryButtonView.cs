using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class RetryButtonView : UIBehaviour, IRetryButtonView
    {
        public IObservable<Unit> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }
    }
}