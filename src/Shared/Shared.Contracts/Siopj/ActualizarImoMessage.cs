using MassTransit.Orchestrator;

namespace Shared.Contracts.Siopj;

public record ActualizarImoMessage : IEventMessage
{
    public string IMO { get; init; } = default!;
    public string TipoNave { get; init; } = default!;
    public string Nombre { get; init; } = default!;
    public string CodigoBandera { get; init; } = default!;
    public decimal CaladoMaximo { get; init; }
    public decimal Eslora { get; init; }
    public decimal TRB { get; init; }
    public decimal TRN { get; init; }
    public decimal TPM { get; init; }
}
