using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public interface IProgramaOperacionalRepository : IRepository<ProgramaOperacional>
{
    int UltimoAZ(DateTime date);
    Task<int> UltimoAZAsync(DateTime date, CancellationToken ct = default!);
}
