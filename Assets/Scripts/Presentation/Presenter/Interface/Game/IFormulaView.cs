using MakeTen.Domain.Model.Game;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IFormulaView : IView
    {
        void RenderFormula(IFormulaModel formula);
    }
}