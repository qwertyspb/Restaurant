using Basket.Application.Extensions;
using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Application.Validators;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class GetCartHandler : IRequestHandler<GetCartQuery, CartResponse>
{
    private readonly ICartRepository _repo;

    public GetCartHandler(ICartRepository repo)
    {
        _repo = repo;
    }

    public async Task<CartResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        request.Validate(new UserNameValidator<GetCartQuery>());

        var cart = await _repo.GetCart(request.UserName);
        return BasketMapper.Mapper.Map<CartResponse>(cart);
    }
}