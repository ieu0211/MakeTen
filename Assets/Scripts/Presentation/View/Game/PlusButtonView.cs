using System;
using Application;
using MakeTen.Presentation.Presenter.Interface.Game;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public class PlusButtonView : UIBehaviour, IPlusButtonView
    {
        public IObservable<Enumerate.Operation> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().Select(_ => Enumerate.Operation.Plus);
        }
    }
}