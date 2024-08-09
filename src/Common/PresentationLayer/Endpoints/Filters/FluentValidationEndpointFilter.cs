using System.Reflection;
using Common.Presentation.Endpoints.Common;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Common.Presentation.Endpoint.Filters;

public class FluentValidationEndpointFilter
: IEndpointFilter
{
    private readonly ILogger<FluentValidationEndpointFilter> _logger;
    public FluentValidationEndpointFilter(ILogger<FluentValidationEndpointFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        foreach (var argument in context.Arguments)
        {
            if (argument is null) continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;
            if (validator is not null)
            {
                var validationResult = await validator.ValidateAsync(new ValidationContext<object>(argument));
                if (!validationResult.IsValid)
                {
                    var httpErrorResponse = new HttpErrorResponse
                    {
                        Type = nameof(ValidationFailure),
                        Status = StatusCodes.Status400BadRequest
                    };

                    var errors = new List<object>();

                    foreach (var e in validationResult.Errors)
                    {
                        errors.Add(new
                        {
                            Code = e.ErrorCode,
                            Field = FormatFieldName(e.PropertyName),
                            Error = e.ErrorMessage,
                            ArgumentValue = GetArgumentValue(argument, e.PropertyName),
                            ValidatorArguments = GetValidatorArguments(e)
                        });

                        _logger.LogInformation("The validator of argument '{Property}' found error: '{Error}'. Argument value: '{Value}'.",
                                e.PropertyName, e.ErrorMessage, GetArgumentValue(argument, e.PropertyName));
                    }

                    httpErrorResponse.Errors = errors.ToArray();

                    return Results.BadRequest(httpErrorResponse);
                }
            }
        }

        return await next(context);
    }

    private static string FormatFieldName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        if (value.All(char.IsUpper))
        {
            return value.ToLowerInvariant();
        }

        return char.ToLowerInvariant(value[0]) + value[1..];
    }

    private static object? GetArgumentValue(object argument, string propertyName)
    {
        var property = argument.GetType().GetProperty(propertyName);
        return property?.GetValue(argument);
    }

    private static Dictionary<string, object>? GetValidatorArguments(ValidationFailure failure)
    {
        var result = new Dictionary<string, object>();
        if (failure.FormattedMessagePlaceholderValues is not null)
        {
            foreach (var placeholder in failure.FormattedMessagePlaceholderValues)
            {
                if (placeholder.Value is not null)
                {
                    result.Add(FormatFieldName(placeholder.Key), placeholder.Value);
                }
            }
        }        
    
        return result.Count > 0 ? result : null;
    }

}
