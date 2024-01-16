using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Core.Entities;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateOrUpdateCartHandler : IRequestHandler<CreateOrUpdateCartCommand>
{
    private readonly ICartRepository _repo;

    public CreateOrUpdateCartHandler(ICartRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(CreateOrUpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repo.GetCart(request.UserName)
                   ?? new Cart { UserName = request.UserName };

        var itemsToAdd = BasketMapper.Mapper.Map<List<CartItem>>(request.Items);

        foreach (var itemToAdd in itemsToAdd)
        {
            var inCartItem = cart.Items.FirstOrDefault(x => x.ProductId == itemToAdd.ProductId);

            if (inCartItem is null)
            {
                cart.Items.Add(itemToAdd);
                continue;
            }

            inCartItem.Quantity += itemToAdd.Quantity;
        }

        await _repo.CreateOrUpdateCart(cart);
    }
}