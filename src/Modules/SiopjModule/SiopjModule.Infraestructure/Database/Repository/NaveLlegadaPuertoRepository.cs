using Common.Infraestructure.Database;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Database.Repository;

public sealed class NaveLlegadaPuertoRepository
: Repository<NaveLlegadaPuerto, SiopjContext>, INaveLlegadaPuertoRepository
{
    public NaveLlegadaPuertoRepository(SiopjContext context) : base(context)
    {
    }
}
