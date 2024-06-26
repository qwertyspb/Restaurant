﻿namespace Basket.API.Models;

public class GetCartApiModel
{
    public string UserName { get; set; }
    public TableItemApiModel TableItem { get; set; }
    public List<ProductItemApiModel> ProductItems { get; set; }
    public decimal TotalPrice { get; set; }
}