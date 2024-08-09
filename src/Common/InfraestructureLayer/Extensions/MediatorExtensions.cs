using MediatR;
using Microsoft.EntityFrameworkCore;
using Common.Domain.SeedWork;

namespace Common.Infraestructure.Extensions;

public static class MediatorExtensions
{
    public static async Task DispatchDomainEventsBeforeAsync(this IMediator mediator, DbContext ctx, CancellationToken ct = default!)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.BeforeDomainEvents != null && x.Entity.BeforeDomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.BeforeDomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearBeforeDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent, ct);
    }

    public static async Task DispatchDomainEventsAfterAsync(this IMediator mediator, DbContext ctx, CancellationToken ct = default!)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.AfterDomainEvents != null && x.Entity.AfterDomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.AfterDomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearAfterDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent, ct);
    }
}
