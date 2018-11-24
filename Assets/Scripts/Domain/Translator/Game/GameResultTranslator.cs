using MaketTen.Data.Entity.Game;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.Translator.Interface;

namespace MakeTen.Domain.Translator.Game
{
    public interface IGameResultTranslator : ITranslator<IGameResultEntity, IGameResultModel>
    {
    }
    
    public class GameResultTranslator : IGameResultTranslator
    {
        public IGameResultModel Translate(IGameResultEntity entity)
        {
            return new GameResultModel(entity.Score);
        }
    }
}