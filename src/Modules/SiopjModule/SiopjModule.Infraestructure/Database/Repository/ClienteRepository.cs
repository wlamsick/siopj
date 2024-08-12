using Common.Infraestructure.Database;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Database.Repository;

public sealed class ClienteRepository
: Repository<Cliente, SiopjContext>, IClienteRepository
{
    public ClienteRepository(SiopjContext context) : base(context)
    {
    }

    public int UltimoCodigo()
    {
        return _context.Set<Cliente>()
            .Where(p => p.Codigo < 9000)
            .Max(p => p.Codigo);
    }
}
