using Basket.Application.Dto;
using MediatR;

namespace Basket.Application.Commands;

public class AddProductsToCartCommand : UserNameBasedRequest, IRequest
{
    public List<ProductItemDto> ProductItems { get; set; }
}