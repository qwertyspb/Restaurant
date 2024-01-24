using Basket.Application.Commands;
using FluentValidation;

namespace Basket.Application.Validators;

public class UserNameValidator<T> : AbstractValidator<T> where T : UserNameBasedRequest
{
    public UserNameValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(UserNameBasedRequest.UserName)} property must have value.");
    }
}