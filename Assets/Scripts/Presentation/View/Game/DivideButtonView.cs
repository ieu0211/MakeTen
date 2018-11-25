using System;
using Application;
using DG.Tweening;
using MakeTen.Application.Manager;
using MakeTen.Presentation.Presenter.Interface.Game;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MakeTen.Presentation.View.Game
{
    public sealed class DivideButtonView : UIBehaviour, IDivideButtonView
    {
        [Inject] private SoundManager soundManager { get; }
        
        [SerializeField] private Transform mainImageTransform;
        
        public IObservable<Enumerate.Operation> OnClickAsObservable()
        {
            return this.OnPointerClickAsObservable().Select(_ => Enumerate.Operation.Divide);
        }

        public void Correct()
        {
            soundManager.PlayPositiveSe();

            DOTween.Sequence()
                .Append(mainImageTransform.DOLocalMoveY(150, 0.1f))
                .Append(mainImageTransform.DOLocalMoveY(0, 0.1f));
        }

        public void InCorrect()
        {
            soundManager.PlayNegativeSe();

            mainImageTransform.DOShakePosition(0.2f, 10f);
        }
    }
}