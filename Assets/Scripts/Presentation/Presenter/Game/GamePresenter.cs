using System;
using Application;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.UseCase.Game;
using MakeTen.Domain.UseCase.Interface.Game;
using MakeTen.Presentation.Presenter.Interface.Game;
using UniRx;
using Unity.Jobs;
using Zenject;

namespace MakeTen.Presentation.Presenter.Game
{
    public class GamePresenter : IGamePresenter
    {
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
    }
}