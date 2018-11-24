using Domain.Repository.Interface;
using MaketTen.Data.Entity.Game;
using Zenject;

namespace Maketen.Data.Repository.Game
{
    public interface IGameResultRepository : IRepository
    {
        IGameResultEntity GetEntity();
        void SaveEntity(IGameResultEntity entity);
    }
    
    public class GameResultRepository : IGameResultRepository
    {
        public IGameResultEntity GetEntity()
        {
            return new GameResultEntity();
        }
        
        public void SaveEntity(IGameResultEntity entity)
        {
        }
    }
}