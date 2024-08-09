using System.Text.Json.Serialization;
using Common.Domain.Events;

namespace Common.Domain.SeedWork;

public abstract class Entity : IEntity
{
    private readonly List<IDomainEvent> _beforeDomainEvents = new();
    private readonly List<IDomainEvent> _afterDomainEvents = new();

    [JsonIgnore]
    public IReadOnlyCollection<IDomainEvent> BeforeDomainEvents => _beforeDomainEvents.AsReadOnly();
    
    [JsonIgnore]
    public IReadOnlyCollection<IDomainEvent> AfterDomainEvents => _afterDomainEvents.AsReadOnly();

    public void RaiseDomainEventBefore(IDomainEvent domainEvent)
    {
        _beforeDomainEvents.Add(domainEvent);
    }

    public void RaiseDomainEventAfter(IDomainEvent domainEvent)
    {
        _afterDomainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        if (_beforeDomainEvents.Contains(domainEvent))
        {
            _beforeDomainEvents?.Remove(domainEvent);
        }

        if (_afterDomainEvents.Contains(domainEvent))
        {
            _afterDomainEvents?.Remove(domainEvent);
        }        
    }

    public void ClearBeforeDomainEvents()
    {
        _beforeDomainEvents?.Clear();        
    }

    public void ClearAfterDomainEvents()
    {
        _afterDomainEvents?.Clear();
    }
}
