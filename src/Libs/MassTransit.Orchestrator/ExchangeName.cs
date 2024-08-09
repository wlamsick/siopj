using Common.Domain.Events;

namespace MassTransit.Orchestrator;

public static class ExchangeName
{
    public static string QueueName<TConsumer, TMessage>() 
        where TConsumer : IConsumer
        where TMessage : IEventMessage
    {
        string nameConsumer = typeof(TConsumer).Namespace?.ToLower() ?? typeof(TConsumer).Name.ToLower();
        string messageName = typeof(TMessage).Name.ToLower();

        return $"{nameConsumer}:{messageName}";
    }
}
