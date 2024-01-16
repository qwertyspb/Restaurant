﻿namespace Basket.API.Models;

public class CartItemApiModel
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Image { get; set; }
}