using Catalog.Application.Commands;
using FluentValidation;

namespace Catalog.Application.Validators;

public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
{
    public CreateTableCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage($"{nameof(CreateTableCommand.Amount)} must be greater than 0");

        RuleFor(x => x.Capacity)
            .GreaterThan(0)
            .WithMessage($"{nameof(CreateTableCommand.Capacity)} must be greater than 0");
    }
}