namespace DesignPatterns.Model
{
    internal class DefaultEntityCalculate<TEntity> : IEntityCalculate<TEntity>
        where TEntity : class
    {
        public TResult Calculate<TResult>(TEntity entity, string property)
        {
            return default;
        }
    }
}