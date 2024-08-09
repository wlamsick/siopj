using MediatR;

namespace Common.Domain.Events;

public interface IDomainRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IDomainRequest<TResponse>
{

}
