using MakeTen.Application;
using MakeTen.Domain.Model.Interface;
using UniRx;

namespace MakeTen.Domain.Model.Game
{
    public interface IGameStateModel : IModel
    {
        IReactiveProperty<float> RemainingTime { get; }
        ISubject<Unit> OnCorrectSubject { get; }
        ISubject<Unit> OnIncorrectSubject { get; }
    }
    
    public sealed class GameStateModel : IGameStateModel
    {
        public GameStateModel(float remainingTime)
        {
            RemainingTime = new ReactiveProperty<float>(remainingTime);
        }
        
        public IReactiveProperty<float> RemainingTime { get; }
        public ISubject<Unit> OnCorrectSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> OnIncorrectSubject { get; } = new Subject<Unit>();
    }
}