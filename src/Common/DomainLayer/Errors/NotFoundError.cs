using System.Diagnostics;
using Common.Domain.Abstractions;

namespace Common.Domain.Errors;

public class NotFoundError
: Error
{
    public NotFoundError(string? message = null)
    {
        var trace = new StackTrace();
        var frame = trace.GetFrame(1);
        var callingClass = frame?.GetMethod()?.ReflectedType?.Name;

        Code = callingClass ?? nameof(Error);
        Message = message;
    }
}
