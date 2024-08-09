using FluentValidation;
using FluentValidation.Validators;

namespace Common.Application.Validators;

public class NotFindValidator<T, TProperty>
: IAsyncPropertyValidator<T, TProperty>, IPropertyValidator<T, TProperty>
{    
    public NotFindValidator(Func<TProperty, ValidationContext<T>, bool> action)
    {
        _action = action;
    }

    public NotFindValidator(Func<TProperty, ValidationContext<T>, CancellationToken, Task<bool>> actionAsync)
    {
        _actionAsync = actionAsync;
    }

    private readonly Func<TProperty, ValidationContext<T>, bool>? _action;
    private readonly Func<TProperty, ValidationContext<T>, CancellationToken, Task<bool>>? _actionAsync;

    public string Name => "NotExitsValidator";

    public string GetDefaultMessageTemplate(string errorCode)
    => "Could not find '{PropertyName}' with value {PropertyValue}.";

    public bool IsValid(ValidationContext<T> context, TProperty value)
    {             
        return _action!(value, context);
    }

    public async Task<bool> IsValidAsync(ValidationContext<T> context, TProperty value, CancellationToken cancellation)
    {
        return await _actionAsync!(value, context, cancellation);
    }
}
