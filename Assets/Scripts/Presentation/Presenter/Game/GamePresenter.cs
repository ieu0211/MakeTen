using System;
using Application;
using MakeTen.Application.Manager;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.UseCase.Interface.Game;
using MakeTen.Presentation.Presenter.Interface.Game;
using UniRx;
using Zenject;

namespace MakeTen.Presentation.Presenter.Game
{
    public sealed class GamePresenter : IGamePresenter, IInitializable
    {
        [Inject] private SoundManager soundManager { get; }
        [Inject] private ITimerView timerView { get; }
        [Inject] private IScoreView scoreView { get; }
        [Inject] private IFormulaView formulaView { get; }
        [Inject] private IPlusButtonView plusButtonView { get; }
        [Inject] private IMinusButtonView minusButtonView{ get; }
        [Inject] private IMultiplyButtonView multiplyButtonView { get; }
        [Inject] private IDivideButtonView divideButtonView { get; }

        public void RenderTimer(float time)
        {
            timerView.Render(time);
        }

        public void RenderScore(int score)
        {
            scoreView.RenderScore(score);
        }

        public void RenderFormula(IFormulaModel formula)
        {
            formulaView.RenderFormula(formula);
        }

        public IObservable<Enumerate.Operation> OnSelectOperation()
        {
            return Observable.Merge(
                plusButtonView.OnClickAsObservable(),
                minusButtonView.OnClickAsObservable(),
                multiplyButtonView.OnClickAsObservable(),
                divideButtonView.OnClickAsObservable()
            );
        }

        public void Correct(Enumerate.Operation operation)
        {
            switch (operation)
            {
                case Enumerate.Operation.Plus:
                    plusButtonView.Correct();
                    break;
                case Enumerate.Operation.Minus:
                    minusButtonView.Correct();
                    break;
                case Enumerate.Operation.Multiply:
                    multiplyButtonView.Correct();
                    break;
                case Enumerate.Operation.Divide:
                    divideButtonView.Correct();
                    break;
            }
        }
        
        public void Incorrect(Enumerate.Operation operation)
        {
            switch (operation)
            {
                case Enumerate.Operation.Plus:
                    plusButtonView.InCorrect();
                    break;
                case Enumerate.Operation.Minus:
                    minusButtonView.InCorrect();
                    break;
                case Enumerate.Operation.Multiply:
                    multiplyButtonView.InCorrect();
                    break;
                case Enumerate.Operation.Divide:
                    divideButtonView.InCorrect();
                    break;
            }
        }

        public void Initialize()
        {
            soundManager.PlayGameBgm();
        }
    }
}