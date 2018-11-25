using Domain.Repository.Interface;
using MaketTen.Data.Entity.Game;

namespace Maketen.Data.Repository.Game
{
    public interface IGameStateRepository : IRepository 
    {
        IGameStateEntity GetEntity();
    }
    
    public sealed class GameStateRepository : IGameStateRepository
    {
        public IGameStateEntity GetEntity()
        {
            return new GameStateEntity();
        }
    }
}