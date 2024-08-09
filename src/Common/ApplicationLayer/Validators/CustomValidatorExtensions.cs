using FluentValidation;

namespace Common.Application.Validators;

public static class CustomValidatorExtensions
{
  public static IRuleBuilderOptions<T, string?> StringLenght<T>(this IRuleBuilder<T, string?> ruleBuilder, int requiredLength)
  {
    return ruleBuilder.SetValidator(new StringLengthValidator<T>(requiredLength));
  }

  public static IRuleBuilderOptions<T, int?> NumberLenght<T>(this IRuleBuilder<T, int?> ruleBuilder, int requiredLength)
  {
    return ruleBuilder.SetValidator(new NumberLengthValidator<T>(requiredLength));
  }

  public static IRuleBuilderOptions<T, string> Password<T>(
      this IRuleBuilder<T, string> ruleBuilder,
      int minLength = 8,
      int maxLength = 16,
      bool forceUppercase = true,
      bool forceLowercase = true,
      bool forceUseDigits = true,
      bool forceUseSpecialCharacters = true)
  {    
    return ruleBuilder.Password(minLength, maxLength, forceUppercase, forceLowercase, forceUseDigits, forceUseSpecialCharacters);
  }

  public static IRuleBuilderOptions<T, string> ValidateNameRules<T>(this IRuleBuilder<T, string> ruleBuilder, int minLength = 100)
  {
    return ruleBuilder.MaximumLength(minLength);
  }

  public static IRuleBuilderOptions<T, TProperty> AlreadyExistsAsync<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, ValidationContext<T>, CancellationToken, Task<bool>> action)
  {
    return ruleBuilder.SetAsyncValidator(new AlreadyExistsValidator<T, TProperty>(action));
  }

  public static IRuleBuilderOptions<T, TProperty> AlreadyExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, ValidationContext<T>, bool> action)
  {
    return ruleBuilder.SetValidator(new AlreadyExistsValidator<T, TProperty>(action));
  }

  public static IRuleBuilderOptions<T, TProperty> NotFind<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, ValidationContext<T>, bool> action)
  {
    return ruleBuilder.SetValidator(new NotFindValidator<T, TProperty>(action));
  }

  public static IRuleBuilderOptions<T, TProperty> NotFindAsync<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, ValidationContext<T>, CancellationToken, Task<bool>> action)
  {
    return ruleBuilder.SetAsyncValidator(new NotFindValidator<T, TProperty>(action));
  }

}
