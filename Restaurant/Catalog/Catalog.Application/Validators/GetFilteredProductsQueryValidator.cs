using Catalog.Application.Queries;
using FluentValidation;

namespace Catalog.Application.Validators;

public class GetFilteredProductsQueryValidator : AbstractValidator<GetFilteredProductsQuery>
{
    public GetFilteredProductsQueryValidator()
    {
        RuleFor(x => x.SearchFilter)
            .NotNull()
            .WithMessage($"{nameof(GetFilteredProductsQuery.SearchFilter)} must not be null");
    }
}