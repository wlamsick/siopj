using Common.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.Repository;

public sealed class ProgramaOperacionalRepository
: Repository<ProgramaOperacional, SiopjContext>, IProgramaOperacionalRepository
{
    public ProgramaOperacionalRepository(SiopjContext context) : base(context)
    {
    }

    public int UltimoAZ(DateTime date)
    {
        return _context.Set<ProgramaOperacional>()
            .Where(p => p.Anio == date.Year)
            .Max(p => p.NumeroAZ);
        /* var az = _context.Set<ProgramaOperacional>()
            .Where(p => p.Anio == date.Year)
            .Max(p => p.NumeroAZ);
        if (az == 0)
        {
            az = date.Year * 10000;
        }

        return az; */
    }

    public Task<int> UltimoAZAsync(DateTime date, CancellationToken ct = default)
    {
        return _context.Set<ProgramaOperacional>()
            .Where(p => p.Anio == date.Year)
            .MaxAsync(p => p.NumeroAZ, ct);
    }
}