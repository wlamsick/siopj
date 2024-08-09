namespace Shared.Contracts.Siopj;

public record RegistrarMarcaAtraqueMessage : IEventMessage
{
    public int NumeroAZ { get; init; }
    public DateTime Fecha { get; init; }
    public string Puesto { get; init; } = default!;
    public int CodigoOperacion { get; init; }
}
