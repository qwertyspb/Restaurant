namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public ShoppingCartResponse()
    {
        
    }

    public ShoppingCartResponse(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
    public List<CartItemResponse> Items { get; set; }

    public decimal TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(item => item.Price * item.Quantity);
            return totalPrice;
        }
    }
}