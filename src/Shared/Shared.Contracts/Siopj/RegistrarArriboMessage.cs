using MassTransit.Orchestrator;

namespace Shared.Contracts.Siopj;

public record RegistrarArriboMessage : IEventMessage
{
    public int NumeroAZ { get; init; }
    public string IMO { get; init; } = default!;
    public DateTime ETA { get; init; }
    public DateTime ETB { get; init; }
    public DateTime ETC { get; init; }
    public DateTime ETD { get; init; }
    public string IdentificacionNaviero { get; init; } = default!;
    public string Naviero { get; init; } = default!;
    public string? IdentificacionEstibador { get; init; }
    public string? Estibador { get; init; }
    public string PuertoInicial { get; init; } = default!;
    public string PuertoProcedencia { get; init; } = default!;
    public string PuertoDestino { get; init; } = default!;
    public string PuertoFinal { get; init; } = default!;
    public decimal CaladoProyectado { get; init; }
    public string TipoCarga { get; init; } = default!;
    public int CodigoModalidad { get; init; }
}
