namespace Traceability.Domain._Shared;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    TEntity Add(TEntity entity);
    void Delete(TEntity entity);
}