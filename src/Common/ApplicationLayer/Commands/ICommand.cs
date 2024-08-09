using MediatR;

namespace Common.Application.Commands;

public interface ICommand<TResponse> : IRequest<TResponse>    
{
    
}

public interface ICommand : IRequest
{

}

