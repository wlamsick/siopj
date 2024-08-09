using MassTransit.Orchestrator;

namespace Shared.Contracts.Siopj;

public record RegistrarArriboMessage : IEventMessage
{
    public int NumeroAz { get; init; }
    public string Imo { get; init; } = default!;
    public DateTime ETA { get; init; }
    public DateTime ETB { get; init; }
    public DateTime ETC { get; init; }
    public DateTime ETD { get; init; }
    public int CodigoCliente { get; init; }
    public int? CodigoEstibador { get; init; }
    public string PuertoInicial { get; init; } = default!;
    public string PuertoProcedencia { get; init; } = default!;
    public string PuertoDestino { get; init; } = default!;
    public string PuertoFinal { get; init; } = default!;
    public string LineaNaviera { get; init; } = default!;
    public decimal CaladoProyectado { get; init; }
    public string TipoCarga { get; init; } = default!;
    public int ContenedoresImpo { get; init; }
    public int ContenedoresExpo { get; init; }
    public decimal TonelajeImpo { get; init; }
    public decimal TonelajeExpo { get; init; }
    public string Usuario { get; init; } = default!;
    public int CodigoModalidad { get; init; }
}
