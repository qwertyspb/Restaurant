namespace Basket.API.Models;

public class GetCartApiModel
{
    public string UserName { get; set; }
    public List<CartItemApiModel> Items { get; set; }
    public decimal TotalPrice { get; set; }
}