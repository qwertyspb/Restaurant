using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class GetBasketByUserNameHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
{
    private readonly IBasketRepository _repo;

    public GetBasketByUserNameHandler(IBasketRepository repo)
    {
        _repo = repo;
    }

    public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
    {
        var cart = await _repo.GetBasket(request.UserName);
        return BasketMapper.Mapper.Map<ShoppingCartResponse>(cart);
    }
}