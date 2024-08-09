using MediatR;

namespace Common.Application.Commands;

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : ICommand<TResponse>
{
    
}

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : ICommand
{

}
