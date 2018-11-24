namespace DefaultNamespace
{
    public interface ITranslator<in TEntity, out TModel> where TEntity : IEntity
    {
        TModel Translate(TEntity entity);
    }
}