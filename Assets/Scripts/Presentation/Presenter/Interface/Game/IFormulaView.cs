using MakeTen.Domain.Model.Game;
using MakeTen.Domain.UseCase.Game;

namespace MakeTen.Presentation.Presenter.Interface.Game
{
    public interface IFormulaView : IView
    {
        void RenderFormula(FormulaModel formula);
    }
}