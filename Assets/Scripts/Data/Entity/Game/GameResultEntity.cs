using Maketen.Data.Entity;
using UnityEngine.SocialPlatforms.Impl;

namespace MaketTen.Data.Entity.Game
{
    public interface IGameResultEntity : IEntity
    {
        int Score { get; set; }
    }
    
    public class GameResultEntity : IGameResultEntity
    {
        public int Score { get; set; }
    }
}