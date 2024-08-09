using FluentValidation;
using FluentValidation.Validators;

namespace Common.Application.Validators;

internal class NumberLengthValidator<T>
: IPropertyValidator<T, int?>
{
    public NumberLengthValidator(int requiredLength)
    {
        RequiredLength = requiredLength;
    }

    public int RequiredLength { get; private set; }
    public string Name => "NumberLengthValidator";

    public string GetDefaultMessageTemplate(string errorCode)
    => "'{PropertyName}' must be {RequiredLength} characters long.";

    public bool IsValid(ValidationContext<T> context, int? value)
    {        
        context.MessageFormatter.AppendArgument("RequiredLength", RequiredLength);        

        if (value is null) return true;


        return value.Value.ToString().Length == RequiredLength;
    }
    
}
