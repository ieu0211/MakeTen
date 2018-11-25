using System;
using Maketen.Data.Entity;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace MaketTen.Data.Entity.Game
{
    public interface IGameResultEntity : IEntity
    {
        int Score { get; set; }
    }
    
    [Serializable]
    public class GameResultEntity : IGameResultEntity
    {
        public GameResultEntity(int score)
        {
            Score = score;
        }
        
        public int Score { get; set; }
    }
}