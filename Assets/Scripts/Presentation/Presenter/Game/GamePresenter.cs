using System;
using Application;
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
        [Inject] private ITimerView _timerView { get; }
        
        [Inject] private IScoreView _scoreView { get; }
        
        [Inject] private IFormulaView _formulaView { get; }
        
        [Inject] private IPlusButtonView _plusButtonView { get; }
        
        [Inject] private IMinusButtonView minusButtonView{ get; }
        
        [Inject] private IMultiplyButtonView multiplyButtonView { get; }
        
        [Inject] private IDivideButtonView divideButtonView { get; }

        public void RenderTimer(float time)
        {
            _timerView.Render(time);
        }

        public void RenderScore(int score)
        {
            _scoreView.RenderScore(score);
        }

        public void RenderFormula(FormulaModel formula)
        {
            _formulaView.RenderFormula(formula);
        }

        public IObservable<Enumerate.Operation> OnSelectOperation()
        {
            return Observable.Merge(

                _plusButtonView.OnClickAsObservable(),
                minusButtonView.OnClickAsObservable(),
                multiplyButtonView.OnClickAsObservable(),
                divideButtonView.OnClickAsObservable()
                
                );
            
            return _plusButtonView.OnClickAsObservable();
        }
    }
}