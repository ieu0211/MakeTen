using Maketen.Data.Entity;
using MakeTen.Application;
using UniRx;

namespace MaketTen.Data.Entity.Game
{
    public interface IGameStateEntity : IEntity
    {
        float RemainingTime { get; }
    }
    
    public class GameStateEntity : IGameStateEntity
    {
        public float RemainingTime { get; } = Constant.RemainingTime;
    }
}