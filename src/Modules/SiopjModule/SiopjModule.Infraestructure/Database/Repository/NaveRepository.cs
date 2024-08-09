using Common.Infraestructure.Database;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Database.Repository;

public sealed class NaveRepository
: Repository<Nave, SiopjContext>, INaveRepository
{
    public NaveRepository(SiopjContext context) : base(context)
    {
    }
}
