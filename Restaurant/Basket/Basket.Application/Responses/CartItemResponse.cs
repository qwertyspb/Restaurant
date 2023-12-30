﻿namespace Basket.Application.Responses;

public class CartItemResponse
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Image { get; set; }
}