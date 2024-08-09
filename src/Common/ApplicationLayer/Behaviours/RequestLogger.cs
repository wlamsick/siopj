using MediatR.Pipeline;
using Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace Common.Application.Behaviours;

public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IAuthenticatedService _authService;

    public RequestLogger(ILogger logger, IAuthenticatedService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var name = typeof(TRequest).Name;

        _logger.LogInformation("Request: {Name} {@UserId} {@Request}",
            name, _authService.Id, request);

        return Task.CompletedTask;
    }
}
