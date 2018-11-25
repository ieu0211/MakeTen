using Application;
using MakeTen.Domain.Model.Interface;
using UniRx;

namespace MakeTen.Domain.Model.Game
{
    public interface IGameStateModel : IModel
    {
        IReactiveProperty<float> RemainingTime { get; }
        ISubject<Enumerate.Operation> OnCorrectSubject { get; }
        ISubject<Enumerate.Operation> OnIncorrectSubject { get; }
    }
    
    public sealed class GameStateModel : IGameStateModel
    {
        public GameStateModel(float remainingTime)
        {
            RemainingTime = new ReactiveProperty<float>(remainingTime);
        }
        
        public IReactiveProperty<float> RemainingTime { get; }
        public ISubject<Enumerate.Operation> OnCorrectSubject { get; } = new Subject<Enumerate.Operation>();
        public ISubject<Enumerate.Operation> OnIncorrectSubject { get; } = new Subject<Enumerate.Operation>();
    }
}