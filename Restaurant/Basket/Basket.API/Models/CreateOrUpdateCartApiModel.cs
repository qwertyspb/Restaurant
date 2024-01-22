namespace Basket.API.Models;

public class CreateOrUpdateCartApiModel
{
    public string UserName { get; set; }
    public List<CartItemApiModel> Items { get; set; }
}