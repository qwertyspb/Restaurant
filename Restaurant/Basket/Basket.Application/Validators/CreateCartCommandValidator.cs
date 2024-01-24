using Basket.Application.Commands;
using FluentValidation;

namespace Basket.Application.Validators;

public class CreateCartCommandValidator : UserNameValidator<CreateCartCommand>
{
    private readonly TimeSpan _minBookingDuration = TimeSpan.FromHours(1);

    public CreateCartCommandValidator()
    {
        RuleFor(x => x.VisitorsAmount)
            .GreaterThan(0)
            .WithMessage($"{nameof(CreateCartCommand.VisitorsAmount)} must be greater than 0");

        var now = DateTime.Now;
        RuleFor(x => x.BookingStartDate)
            .GreaterThanOrEqualTo(now)
            .WithMessage($"{nameof(CreateCartCommand.BookingStartDate)} must be greater than now={now}");

        RuleFor(x => x.BookingDuration)
            .GreaterThanOrEqualTo(_minBookingDuration)
            .WithMessage($"{nameof(CreateCartCommand.BookingDuration)} must be greater than {_minBookingDuration}");
    }
}