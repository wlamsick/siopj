using Common.Domain.Events;

namespace MassTransit.Orchestrator;

public interface IMessageConsumer<TMessage> : IConsumer<TMessage>
where TMessage : class, IEventMessage
{
    
}
