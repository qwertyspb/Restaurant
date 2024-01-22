using Basket.Application.Dto;
using MediatR;

namespace Basket.Application.Commands;

public class AddProductsToCartCommand : IRequest
{
    public string UserName { get; set; }
    public List<ProductItemDto> ProductItems { get; set; }
}