using Common.Infraestructure.Database;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.Repository;

public sealed class PuertoRepository
: Repository<Puerto, SiopjContext>, IPuertoRepository
{
    public PuertoRepository(SiopjContext context) : base(context)
    {
    }
}