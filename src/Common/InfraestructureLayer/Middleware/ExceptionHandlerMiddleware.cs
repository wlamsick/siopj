using System.Net;
using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Common.Infraestructure.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger? _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next)
        => _next = next;

    public ExceptionHandlerMiddleware(
        RequestDelegate next,
        ILogger logger)
    {
        _next = next;
        _logger = logger;
    }



    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        if (_logger is not null)
        {
            EventId eventId = new(exception.HResult, Assembly.GetExecutingAssembly().GetName().Name);
            _logger.LogError(eventId, exception, exception.InnerException?.Message ?? exception.Message, context.Request.Query);
        }

        if (exception is DomainException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
        context.Response.ContentType = "application/json";

        var error = new { exception, context.Response.StatusCode, traceId };
        await context.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}
