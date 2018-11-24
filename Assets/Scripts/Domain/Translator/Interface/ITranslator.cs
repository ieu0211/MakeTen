using Maketen.Data.Entity;

namespace MakeTen.Domain.Translator.Interface
{
    public interface ITranslator<in TEntity, out TModel> where TEntity : IEntity
    {
        TModel Translate(TEntity entity);
    }
}