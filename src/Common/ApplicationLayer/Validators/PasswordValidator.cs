using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Common.Application.Validators;

public class PasswordValidator<T>
: PropertyValidator<T, string>
{
    public PasswordValidator(
        int minLength,
        int maxLength,
        bool forceUppercase,
        bool forceLowercase,
        bool forceUseDigits,
        bool forceUseSpecialCharacters
    )
    {
        MinLength = minLength;
        MaxLength = maxLength;
        ForceUppercase = forceUppercase;
        ForceLowercase = forceLowercase;
        ForceUseDigits = forceUseDigits;
        ForceUseSpecialCharacters = forceUseSpecialCharacters;
    }
    public int MinLength { get; private set; }
    public int MaxLength { get; private set; }
    public bool ForceUppercase { get; private set; }
    public bool ForceLowercase { get; private set; }
    public bool ForceUseDigits { get; private set; }
    public bool ForceUseSpecialCharacters { get; private set; }

    public override string Name => "PasswordValidator";

    private string lowercaseMatchPattern => "[a-z]";
    private string uppercaseMatchPattern => "[A-Z]";
    private string digitMatchPattern => "\\d";
    private string specialCharactersMatchPattern => "\\W";


    public override bool IsValid(ValidationContext<T> context, string value)
    {        
        if (ForceLowercase && !Regex.IsMatch(value, lowercaseMatchPattern))
        {            
            context.MessageFormatter.BuildMessage("'{PropertyName}' must contain at least 1 lowercase letter.");
            return false;
        }

        if (ForceUppercase && !Regex.IsMatch(value, uppercaseMatchPattern))
        {
            context.MessageFormatter.BuildMessage("'{PropertyName}' must contain at least 1 uppercase letter.");
            return false;
        }

        if (ForceUseDigits && !Regex.IsMatch(value, digitMatchPattern))
        {
            context.MessageFormatter.BuildMessage("'{PropertyName}' must contain at least 1 digit.");
            return false;
        }

        if (ForceUseSpecialCharacters && !Regex.IsMatch(value, specialCharactersMatchPattern))
        {
            context.MessageFormatter.BuildMessage("'{PropertyName}' must contain at least 1 special character.");
            return false;
        }

        if (value.Length < MinLength)
        {
            context.MessageFormatter.BuildMessage("'{PropertyName}' must be at least {MinLength} characters long.");
            return false;
        }

        if (value.Length > MaxLength)
        {
            context.MessageFormatter.BuildMessage("'{PropertyName}' must be at most {MaxLength} characters long.");
            return false;
        }

        return true;
    }
    
}
