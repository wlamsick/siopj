using Common.Infraestructure.Database;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Database.Repository;

public sealed class MarcaAtraqueRepository
: Repository<MarcaAtraque, SiopjContext>, IMarcaAtraqueRepository
{
    public MarcaAtraqueRepository(SiopjContext context) : base(context)
    {
    }
}
