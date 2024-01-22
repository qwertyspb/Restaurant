using Basket.Application.Dto;

namespace Basket.Application.Responses;

public class CartResponse
{
    public string UserName { get; set; }
    public TableItemDto TableItem { get; set; }
    public List<ProductItemDto> ProductItems { get; set; }

    public decimal TotalPrice
    {
        get
        {
            var totalPrice = ProductItems.Sum(item => item.Price * item.Quantity);
            return totalPrice;
        }
    }
}