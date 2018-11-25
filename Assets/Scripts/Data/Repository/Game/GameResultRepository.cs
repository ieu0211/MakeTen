using Domain.Repository.Interface;
using MaketTen.Data.Entity.Game;
using MakeTen.Application;
using UnityEngine;

namespace Maketen.Data.Repository.Game
{
    public interface IGameResultRepository : IRepository
    {
        IGameResultEntity GetEntity();
        void Write(IGameResultEntity entity);
        GameResultEntity Read();
    }
    
    public sealed class GameResultRepository : IGameResultRepository
    {
        public IGameResultEntity GetEntity()
        {
            return new GameResultEntity(0);
        }
        
        public void Write(IGameResultEntity entity)
        {
            PlayerPrefs.SetInt(Constant.PlayerPrefsKey.LastGameResultScore, entity.Score);
        }

        public GameResultEntity Read()
        {
            var score = PlayerPrefs.GetInt(Constant.PlayerPrefsKey.LastGameResultScore);
            return new GameResultEntity(score);
        }
    }
}