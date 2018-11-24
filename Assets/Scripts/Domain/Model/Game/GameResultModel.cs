using MakeTen.Domain.Model.Interface;
using UniRx;

namespace MakeTen.Domain.Model.Game
{
    public interface IGameResultModel : IModel
    {
        IReactiveProperty<int> Score { get; }
    }
    
    public class GameResultModel : IGameResultModel
    {
        public GameResultModel(int score)
        {
            Score = new ReactiveProperty<int>(score);
        }
        
        public IReactiveProperty<int> Score { get; }
    }
}