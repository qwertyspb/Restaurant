namespace Basket.API.Models;

public class AddProductsToCartApiModel
{
    public string UserName { get; set; }
    public List<ProductItemApiModel> ProductItems { get; set; }
}