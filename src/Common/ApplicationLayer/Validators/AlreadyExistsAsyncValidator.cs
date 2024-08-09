using FluentValidation;
using FluentValidation.Validators;

namespace Common.Application.Validators;

internal class AlreadyExistsValidator<T, TProperty>
: IAsyncPropertyValidator<T, TProperty>, IPropertyValidator<T, TProperty>
{
    public AlreadyExistsValidator(Func<TProperty, ValidationContext<T>, CancellationToken, Task<bool>> action)
    {
        _actionAsync = action;
    }

    public AlreadyExistsValidator(Func<TProperty, ValidationContext<T>, bool> action)
    {
        _action = (value, context) => action(value, context);
    }

    private readonly Func<TProperty, ValidationContext<T>, CancellationToken, Task<bool>>? _actionAsync;
    private readonly Func<TProperty, ValidationContext<T>, bool>? _action;

    public string Name => "AlreadyExistsValidator";

    public string GetDefaultMessageTemplate(string errorCode)
    => "'{PropertyName}' with value {PropertyValue} already exists.";

    public bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (value is null) return true;
        return _action!(value, context);
    }

    public async Task<bool> IsValidAsync(ValidationContext<T> context, TProperty value, CancellationToken cancellation)
    {        
        if (value is null) return true;
        return !await _actionAsync!(value, context, cancellation);
    }
}
