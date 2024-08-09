namespace Common.Domain.Exceptions;

public abstract class DomainException : Exception
{
    private string? _customMessage;

    public string Type
    {
        get { return this.GetType().Name; }
    }

    public override string Message
    {
        get { return _customMessage ?? string.Empty; }
    }
    public DomainException() { }

    public DomainException(string? message)
    {
        _customMessage = message;
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected void SetExceptionMessage(string message, params object[] args)
    {
        _customMessage = string.Format(message, args);
    }

    public void Throw()
    {
        throw this;
    }
}
