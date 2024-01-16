using Basket.Application.Dto;
using MediatR;

namespace Basket.Application.Commands;

public class CreateOrUpdateCartCommand : IRequest
{
    public string UserName { get; set; }
    public List<CartItemDto> Items { get; set; }
}