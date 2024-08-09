using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Common.Domain.SeedWork;

namespace Common.Infraestructure.Database;

public abstract class Repository<TEntity, R> : IRepository<TEntity>
        where TEntity : class, IEntity
        where R : DbContext, IUnitOfWork
{
    protected readonly R _context;

    protected Repository(R context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _context.ChangeTracker.DetectChanges();
    }

    public IUnitOfWork UnitOfWork => _context;

    public virtual TEntity Insert(TEntity entity)
        => _context.Set<TEntity>().Add(entity).Entity;

    public virtual void AddRange(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().AddRange(entities);

    public virtual void Delete(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);

    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().Where(expression).SingleOrDefault();
        if (entity is not null)
            _context.Set<TEntity>().Remove(entity);
    }

    public virtual void DeleteBatch(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().RemoveRange(entities);

    public virtual void Update(TEntity entity)
        => _context.Set<TEntity>().Update(entity);

    public virtual void UpdateRange(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().UpdateRange(entities);

    public virtual bool Exists(Expression<Func<TEntity, bool>> expression)
        => _context.Set<TEntity>().Any(expression);

    public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
    => _context.Set<TEntity>().AnyAsync(expression, cancellationToken: ct);

    public virtual Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
    => _context.Set<TEntity>().Where(expression).ToListAsync(cancellationToken: ct);

    public virtual Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
    => _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync(cancellationToken: ct);

    public virtual Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
    => _context.Set<TEntity>().ToListAsync(cancellationToken: ct);

    public T Insert<T>(T entity) where T : class, IEntity
    {
        return _context.Set<T>().Add(entity).Entity;
    }

    public void Delete<T>(T entity) where T : class, IEntity
    {
        _context.Set<T>().Remove(entity);
    }

    public T Update<T>(T entity) where T : class, IEntity
    {
        return _context.Set<T>().Update(entity).Entity;
    }

    Task<bool> IQueryableRepository<TEntity>.ExistsAsync<T>(Expression<Func<T, bool>> expression, CancellationToken ct)
    {
        return _context.Set<T>().AnyAsync(expression, ct);
    }

    bool IQueryableRepository<TEntity>.Exists<T>(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Any(expression);
    }
}
