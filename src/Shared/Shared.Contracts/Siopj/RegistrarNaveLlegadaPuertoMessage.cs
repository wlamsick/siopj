using MassTransit.Orchestrator;

namespace Shared.Contracts.Siopj;

public record RegistrarNaveLlegadaPuertoMessage : IEventMessage
{
    public int NumeroAZ { get; init; }
}
