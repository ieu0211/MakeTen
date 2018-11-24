using MakeTen.Presentation.Presenter.Interface;

namespace MakeTen.Domain.Model.Game
{
    public interface IResultView : IView
    {
        void RenderResult(int score);
    }
}