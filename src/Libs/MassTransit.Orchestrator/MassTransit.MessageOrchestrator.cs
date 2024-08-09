using Common.Domain.Services;

namespace MassTransit.Orchestrator;

public class MassTransitMessageOrchestrator : IEventBus
{
    private readonly IPublishEndpoint _publisher;

    public MassTransitMessageOrchestrator(IPublishEndpoint publisher)
    {
        _publisher = publisher;
    }
    
    public Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default!) where TMessage : class
    {
        return _publisher.Publish(message, cancellationToken);
    }
}
