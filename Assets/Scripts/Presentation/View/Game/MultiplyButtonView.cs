using System;
using Application;
using MakeTen.Presentation.Presenter.Interface.Game;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public class MultiplyButtonView : UIBehaviour, IMultiplyButtonView
    {
        public IObservable<Enumerate.Operation> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().Select(_ => Enumerate.Operation.Multiply);
        }
    }
}