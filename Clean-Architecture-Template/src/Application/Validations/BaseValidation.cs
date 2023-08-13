namespace Application.Validations;

using FluentValidation;
using FluentValidation.Results;
using MyValidationException = Application.Exceptions.BusinessExceptions.ValidationException;

public static class BaseValidation
{
    public static async Task Validated<T>(this IValidator<T> validator, T payload)
    {
        ValidationResult validationResult = await validator.ValidateAsync(payload);

        if (!validationResult.IsValid)
        {
            throw new MyValidationException(messages: validationResult.Errors);
        }
    }
}
