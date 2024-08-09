using System.Linq.Expressions;
using Common.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Common.Infraestructure.Database;

public class WriteableRepository<TEntity, R> : IWriteableRepository<TEntity>
where TEntity : class, IEntity
where R : DbContext, IUnitOfWork
{
    protected readonly R _context;

    protected WriteableRepository(R context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _context.ChangeTracker.DetectChanges();
    }

    public IUnitOfWork UnitOfWork => _context;

    public TEntity Insert(TEntity entity)
        => _context.Set<TEntity>().Add(entity).Entity;

    public void AddRange(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().AddRange(entities);

    public void Delete(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().Where(expression).SingleOrDefault();
        if (entity is not null)
            _context.Set<TEntity>().Remove(entity);
    }

    public void DeleteBatch(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().RemoveRange(entities);


    public void Update(TEntity entity)
        => _context.Set<TEntity>().Update(entity);    

    public void UpdateRange(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().UpdateRange(entities);

    public T Insert<T>(T entity) where T : class, IEntity
        => _context.Set<T>().Add(entity).Entity;

    public T Update<T>(T entity) where T : class, IEntity
        => _context.Set<T>().Update(entity).Entity;

    void IWriteableRepository<TEntity>.Delete<T>(T entity)
        => _context.Set<T>().Remove(entity);
}
