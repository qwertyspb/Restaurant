using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Core.Entities;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class AddProductsToCartHandler : IRequestHandler<AddProductsToCartCommand>
{
    private readonly ICartRepository _repo;

    public AddProductsToCartHandler(ICartRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(AddProductsToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repo.GetCart(request.UserName)
                   ?? throw new InvalidOperationException("No cart was found.");

        var itemsToAdd = BasketMapper.Mapper.Map<List<ProductItem>>(request.ProductItems);

        foreach (var itemToAdd in itemsToAdd)
        {
            var inCartItem = cart.ProductItems.FirstOrDefault(x => x.ProductId == itemToAdd.ProductId);

            if (inCartItem is null)
            {
                cart.ProductItems.Add(itemToAdd);
                continue;
            }

            inCartItem.Quantity += itemToAdd.Quantity;
        }

        await _repo.CreateOrUpdateCart(cart, TimeSpan.FromDays(1));
    }
}