using Basket.Application.Queries;
using FluentValidation;

namespace Basket.Application.Validators;

public class ApplyCouponQueryValidator : UserNameValidator<ApplyCouponQuery>
{
    public ApplyCouponQueryValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage($"{nameof(ApplyCouponQuery.Code)} property must have value.");
    }
}