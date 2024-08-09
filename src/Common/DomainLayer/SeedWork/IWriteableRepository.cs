using System.Linq.Expressions;

namespace Common.Domain.SeedWork;

public interface IWriteableRepository<TEntity> where TEntity : class, IEntity
{
    IUnitOfWork UnitOfWork { get; }


    TEntity Insert(TEntity entity);
    T Insert<T>(T entity) where T : class, IEntity;
    void AddRange(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void Delete<T>(T entity) where T : class, IEntity;
    void Delete(Expression<Func<TEntity, bool>> expression);
    void DeleteBatch(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    T Update<T>(T entity) where T : class, IEntity;
    void UpdateRange(IEnumerable<TEntity> entities);

}
