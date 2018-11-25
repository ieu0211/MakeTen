using Maketen.Data.Entity;
using MakeTen.Domain.Model.Interface;

namespace MakeTen.Domain.Translator.Interface.ITranslator
{
    public interface IModelTranslator<in TEntity, out TModel> where TEntity : IEntity where TModel : IModel
    {
        TModel Translate(TEntity entity);
    }
    
    public interface IEntityTranslator<in TModel, out TEntity> where TModel : IModel where TEntity : IEntity
    {
        TEntity Translate(TModel model);
    }
}