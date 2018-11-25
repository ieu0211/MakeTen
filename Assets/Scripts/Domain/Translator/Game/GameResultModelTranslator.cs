using MaketTen.Data.Entity.Game;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.Translator.Interface;
using MakeTen.Domain.Translator.Interface.ITranslator;

namespace MakeTen.Domain.Translator.Game
{
    public interface IGameResultTranslator :
        IModelTranslator<IGameResultEntity, IGameResultModel>,
        IEntityTranslator<IGameResultModel, IGameResultEntity>
    {
    }
    
    public class GameResultTranslator : IGameResultTranslator
    {
        public IGameResultModel Translate(IGameResultEntity entity)
        {
            return new GameResultModel(entity.Score);
        }

        public IGameResultEntity Translate(IGameResultModel model)
        {
            return new GameResultEntity(model.Score.Value);
        }
    }
}