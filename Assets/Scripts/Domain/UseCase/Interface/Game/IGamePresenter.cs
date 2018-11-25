using System;
using Application;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.UseCase.Game;

namespace MakeTen.Domain.UseCase.Interface.Game
{
    public interface IGamePresenter : IPresenter
    {
        void RenderTimer(float time);
        void RenderScore(int score);
        void RenderFormula(IFormulaModel formula);

        IObservable<Enumerate.Operation> OnSelectOperation();
    }
}