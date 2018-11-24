using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class ReturnTitleButtonView : UIBehaviour, IReturnTitleButtonView
    {
        public IObservable<Unit> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }
    }
}