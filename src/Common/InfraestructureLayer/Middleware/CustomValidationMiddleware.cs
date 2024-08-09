using Microsoft.AspNetCore.Http;
using FluentValidation;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using MediatR.Pipeline;

namespace Common.Infraestructure.Middleware;

public class CustomValidationMiddleware
{
    private readonly RequestDelegate _next;

    public CustomValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
