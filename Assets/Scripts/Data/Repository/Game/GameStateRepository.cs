using Domain.Repository.Interface;
using MaketTen.Data.Entity.Game;
using Zenject;

namespace Maketen.Data.Repository.Game
{
    public interface IGameStateRepository : IRepository 
    {
        IGameStateEntity GetEntity();
    }
    
    public class GameStateRepository : IGameStateRepository
    {
        public IGameStateEntity GetEntity()
        {
            return new GameStateEntity();
        }
    }
}