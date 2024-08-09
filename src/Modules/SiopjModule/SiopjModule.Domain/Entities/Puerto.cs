using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public partial class Puerto : IEntity
{
    public Puerto() { }

    public string CodigoAduana { get; private set; } = default!;
    public string? CodigoPuerto { get; private set; }
    public string? Descripcion { get; private set; }
    public string Pais { get; private set; } = default!;
}
