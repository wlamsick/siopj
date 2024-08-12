using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public class Cliente : IEntity
{
    public Cliente() {}    

    public int Codigo { get; private set; }
    public string Nombre { get; private set; } = default!;
    public long CedulaJuridica { get; private set; } = default!;
    public int? TipoCliente { get; private set; }

    public static Cliente RegistrarNaviero(
        int codCliente,
        string nombre,
        long cedulaJuridica
    )
    {
        return new Cliente
        {
            Codigo = codCliente,
            Nombre = nombre,
            CedulaJuridica = cedulaJuridica,
            TipoCliente = 1
        };
    }

    public static Cliente RegistrarEstibador(
        int codCliente,
        string nombre,
        long cedulaJuridica
    )
    {
        return new Cliente
        {
            Codigo = codCliente,
            Nombre = nombre,
            CedulaJuridica = cedulaJuridica,
            TipoCliente = 2
        };
    }
}
