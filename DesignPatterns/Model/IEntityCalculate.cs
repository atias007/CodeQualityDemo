namespace DesignPatterns.Model
{
    public interface IEntityCalculate<TEntity>
        where TEntity : class
    {
        object Calculate(TEntity entity, string propertyName);
    }
}