using MediatR;

namespace Common.Application.Queries;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : IQuery<TResponse>
{
    
}
