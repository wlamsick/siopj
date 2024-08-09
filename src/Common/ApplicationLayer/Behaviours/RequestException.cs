using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;


namespace Common.Application.Behaviours;

public class RequestException<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : IRequest<TResponse>
    where TException : Exception
{
    private readonly ILogger _logger;
    //private readonly ICurrentUserService _currentUserService;

    public RequestException(ILogger logger)
    {
        _logger = logger;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken ct = default!)
    {
        /* var name = typeof(TRequest).Name;
        
        logger.LogInformation("Request: {Name} {@UserId} {@Request}",
            name, _currentUserService.UserId, request); */
        string message = exception.InnerException?.Message ?? exception.Message;    
        _logger.LogError(exception, "Exception: {message}", message);

        return Task.CompletedTask;
    }
}
