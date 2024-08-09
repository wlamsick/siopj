using MediatR;

namespace Common.Domain.Events;

public interface IDomainRequest<TResponse> : IRequest<TResponse>
{
    
}
