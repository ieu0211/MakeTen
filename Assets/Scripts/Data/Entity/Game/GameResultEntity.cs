using System;
using Maketen.Data.Entity;

namespace MaketTen.Data.Entity.Game
{
    public interface IGameResultEntity : IEntity
    {
        int Score { get; set; }
    }
    
    public class GameResultEntity : IGameResultEntity
    {
        public GameResultEntity(int score)
        {
            Score = score;
        }
        
        public int Score { get; set; }
    }
}