using MaketTen.Data.Entity.Game;
using MakeTen.Domain.Model.Game;
using MakeTen.Domain.Model.Interface;
using MakeTen.Domain.Translator.Interface;

namespace MakeTen.Domain.Translator.Game
{
    public interface IGameStateTranslator : ITranslator<IGameStateEntity, IGameStateModel>
    {
    }
    
    public class GameStateTranslator : IGameStateTranslator
    {
        public IGameStateModel Translate(IGameStateEntity entity)
        {
            return new GameStateModel(entity.RemainingTime);
        }
    }
}