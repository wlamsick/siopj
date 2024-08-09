using System.Linq.Expressions;
using Common.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Common.Infraestructure.Database;

public class QueryableRepository<T, R> : IQueryableRepository<T>
where T : class, IAggregateRoot
where R : DbContext, IUnitOfWork
{
    protected readonly R _context;
    public IUnitOfWork UnitOfWork => _context;   

    protected QueryableRepository(R context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));        
        _context.ChangeTracker.DetectChanges();
    }

    public bool Exists(Expression<Func<T, bool>> expression)
        => _context.Set<T>().Any(expression);

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken ct = default)
        => _context.Set<T>().AnyAsync(expression, cancellationToken: ct);

    public Task<List<T>> FilterAsync(Expression<Func<T, bool>> expression, CancellationToken ct = default)
        => _context.Set<T>().Where(expression).ToListAsync(cancellationToken: ct);

    public Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken ct = default)
        => _context.Set<T>().Where(expression).SingleOrDefaultAsync(cancellationToken: ct);

    public Task<List<T>> GetAllAsync(CancellationToken ct = default)
        => _context.Set<T>().ToListAsync(cancellationToken: ct);

    Task<bool> IQueryableRepository<T>.ExistsAsync<T1>(Expression<Func<T1, bool>> expression, CancellationToken ct)
    {
        return _context.Set<T1>().AnyAsync(expression, cancellationToken: ct);        
    }

    bool IQueryableRepository<T>.Exists<T1>(Expression<Func<T1, bool>> expression)
    {
        return _context.Set<T1>().Any(expression);
    }
}
