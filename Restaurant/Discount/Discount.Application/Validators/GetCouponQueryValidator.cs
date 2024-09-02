using Discount.Application.Queries;
using FluentValidation;

namespace Discount.Application.Validators;

public class GetCouponQueryValidator : AbstractValidator<GetCouponQuery>
{
    public GetCouponQueryValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage($"Parameter '{nameof(GetCouponQuery.Code)}' must be provided");
    }
}