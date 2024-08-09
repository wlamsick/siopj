using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public class Cliente : IEntity
{
    public Cliente() {}

    public int Codigo { get; private set; }
    public string Nombre { get; private set; } = default!;
    public long CedulaJuridica { get; private set; } = default!;
}
