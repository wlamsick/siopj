using MediatR;

namespace Common.Domain.Events;

public interface IDomainEventHandler<TNotification> : INotificationHandler<TNotification> 
    where TNotification : IDomainEvent
{
    
}
