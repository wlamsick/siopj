namespace Common.Domain.SeedWork;

public interface IUnitOfWork
{    
    Task<int> SaveChangesAsync(CancellationToken ct = default!);    
}
