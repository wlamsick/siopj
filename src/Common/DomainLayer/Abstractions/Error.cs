using System.Diagnostics;

namespace Common.Domain.Abstractions;

public class Error
{
    public string Code { get; protected set; }
    public string? Message { get; protected set; }

    public Error(string code, string? message = null)
    {
        Code = code;
        Message = message;
    }

    public Error(string? message = null)
    {
        var trace = new StackTrace();
        var frame = trace.GetFrame(1);
        var callingClass = frame?.GetMethod()?.ReflectedType?.Name;

        Code = callingClass ?? nameof(Error);
        Message = message;
    }

    public static Error Create(string code, string? message = null) => new(code, message);

    public static Error Create(string? message = null)
    {
        return new(message);
    }

    public static readonly Error None = new(string.Empty);

    public static implicit operator Result(Error error) => Result.Failure(error);
}
