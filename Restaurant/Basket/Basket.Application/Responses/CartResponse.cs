using Basket.Application.Dto;

namespace Basket.Application.Responses;

public class CartResponse
{
    public string UserName { get; set; }
    public List<CartItemDto> Items { get; set; }

    public decimal TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(item => item.Price * item.Quantity);
            return totalPrice;
        }
    }
}