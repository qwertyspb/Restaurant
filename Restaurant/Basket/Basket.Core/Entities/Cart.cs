namespace Basket.Core.Entities;

public class Cart
{
    public string UserName { get; set; }
    public TableItem TableItem { get; set; }
    public List<ProductItem> ProductItems { get; set; } = new();
}