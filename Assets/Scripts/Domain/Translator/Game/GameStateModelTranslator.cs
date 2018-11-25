using MaketTen.Data.Entity.Game;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.Model.Interface;
using MakeTen.Domain.Translator.Interface;
using MakeTen.Domain.Translator.Interface.ITranslator;

namespace MakeTen.Domain.Translator.Game
{
    public interface IGameStateModelTranslator : IModelTranslator<IGameStateEntity, IGameStateModel>
    {
    }
    
    public class GameStateModelTranslator : IGameStateModelTranslator
    {
        public IGameStateModel Translate(IGameStateEntity entity)
        {
            return new GameStateModel(entity.RemainingTime);
        }
    }
}