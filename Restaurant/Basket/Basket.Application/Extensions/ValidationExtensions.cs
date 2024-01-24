using FluentValidation;

namespace Basket.Application.Extensions;

public static class ValidationExtensions
{
    public static void Validate<T>(this T request, AbstractValidator<T> validator)
    {
        var result = validator.Validate(request);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);
    }
}