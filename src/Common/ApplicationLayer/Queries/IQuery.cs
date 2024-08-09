using MediatR;

namespace Common.Application.Queries;

public interface IQuery<TResponse> : IRequest<TResponse>    
{
    
}
