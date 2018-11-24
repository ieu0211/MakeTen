using MakeTen.Presentation.Presenter.Interface;

namespace DefaultNamespace
{
    public interface IResultView : IView
    {
        void RenderResult(int score);
    }
}