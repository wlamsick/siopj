using Common.Domain.Abstractions;
using Common.Domain.Errors;
using Common.Presentation.Endpoints.Common;
using Microsoft.AspNetCore.Http;

namespace Common.Presentation.Endpoints;

public static class ResultExtensions
{
    public static IResult ToHttpResponse<T>(this Result<T> result)
    {
        if (result.IsFailure)
        {
            if (result.Error is NotFoundError notFoundError)
            {
                return Results.NotFound(new HttpErrorResponse
                {
                    Type = "Error",
                    Status = StatusCodes.Status404NotFound,
                    Errors = new[]
                    {
                        new
                        {
                            Code = notFoundError.Code,
                            Error = notFoundError.Message ?? "Resource not found."
                        }
                    }
                });
            }

            return Results.BadRequest(new HttpErrorResponse
            {
                Type = "Error",
                Status = StatusCodes.Status400BadRequest,
                Errors = new[]
                {
                    new
                    {
                        Code = result.Error.Code,
                        Error = result.Error.Message ?? "An error occurred."
                    }
                }
            });
        }

        if (result.Value == null)
        {
            return Results.NotFound(new HttpErrorResponse
            {
                Type = "Error",
                Status = StatusCodes.Status404NotFound,
                Errors = new[]
                {
                    new
                    {
                        Code = "NotFound",
                        Error = "Resource not found."
                    }
                }
            });
        }

        return Results.Ok(result.Value);
    }

    public static IResult ToHttpResponse(this Result result)
    {
        if (result.IsFailure)
        {
            if (result.Error is NotFoundError notFoundError)
            {
                return Results.NotFound(new HttpErrorResponse
                {
                    Type = "Error",
                    Status = StatusCodes.Status404NotFound,
                    Errors = new[]
                    {
                        new
                        {
                            Code = notFoundError.Code,
                            Error = notFoundError.Message ?? "Resource not found."
                        }
                    }
                });
            }

            return Results.BadRequest(new HttpErrorResponse
            {
                Type = "Error",
                Status = StatusCodes.Status400BadRequest,
                Errors = new[]
                {
                    new
                    {
                        Code = result.Error.Code,
                        Error = result.Error.Message ?? "An error occurred."
                    }
                }
            });
        }

        return Results.Ok();
    }
}

