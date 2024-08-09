using FluentValidation;
using FluentValidation.Validators;

namespace Common.Application.Validators;

internal class StringLengthValidator<T>
: IPropertyValidator<T, string?>
{
    public StringLengthValidator(int requiredLength)
    {
        RequiredLength = requiredLength;
    }

    public int RequiredLength { get; private set; }
    public string Name => "StringLengthValidator";

    public string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be {RequiredLength} characters long.";

    public bool IsValid(ValidationContext<T> context, string? value)
    {
        context.MessageFormatter.AppendArgument("RequiredLength", RequiredLength);        

        if (value is null) return true;

        return value.Length == RequiredLength;
    }
}
