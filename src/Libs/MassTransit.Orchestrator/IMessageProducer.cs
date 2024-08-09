using MediatR;

namespace MassTransit.Orchestrator;

public interface IMessageProducer<TNotification> : INotificationHandler<TNotification>
    where TNotification : INotification
{
    
}
