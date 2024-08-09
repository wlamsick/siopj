using System.Linq.Expressions;

namespace Common.Domain.SeedWork;

public interface IQueryableRepository<TEntity> where TEntity: class, IEntity
{
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default!);
    Task<List<TEntity>> GetAllAsync(CancellationToken ct = default!);
    Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default!);    
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default!);
    Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> expression, CancellationToken ct = default!) where T : class, IEntity;

    bool Exists(Expression<Func<TEntity, bool>> expression);
    bool Exists<T>(Expression<Func<T, bool>> expression) where T : class, IEntity;
    
}
