namespace Shared.Contracts.Siopj;

public record RegistrarMarcaAtraqueMessage : IEventMessage
{
    public int NumeroAZ { get; init; }
    public DateTime FechaAtraque { get; init; }
    public DateTime FechaDesatraque { get; init; }
    public string Puesto { get; init; } = default!;
}
