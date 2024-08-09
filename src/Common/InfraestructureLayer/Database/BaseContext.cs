using MediatR;
using Microsoft.EntityFrameworkCore;
using Common.Domain.SeedWork;
using Common.Infraestructure.Extensions;

namespace Common.Infraestructure.Database;

public abstract class BaseContext : DbContext, IUnitOfWork
{   
    protected readonly IMediator? _mediator;

    public BaseContext(DbContextOptions options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public BaseContext(DbContextOptions options) : base(options) { }

    public BaseContext() : base() { }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!)
    {
        if (_mediator is null) return await base.SaveChangesAsync(cancellationToken);

        await _mediator.DispatchDomainEventsBeforeAsync(this, cancellationToken);
        var result = await base.SaveChangesAsync(cancellationToken);
        await _mediator.DispatchDomainEventsAfterAsync(this, cancellationToken);
        return result;
    }

    /* public override async Task<int> SaveChangesAsync()
    {
        try
        {
            await _mediator.DispatchDomainEventsAsync(this);
            return await base.SaveChangesAsync();
        }
        catch (ReferenceConstraintException)
        {
            throw new RelatedDataException();
        }
        catch (UniqueConstraintException ex)
        {
            throw ex;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw ex;
        }
    } */
}
