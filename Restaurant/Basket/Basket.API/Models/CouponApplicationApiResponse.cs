namespace Basket.API.Models;

public class CouponApplicationApiResponse
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public decimal? TotalPrice { get; set; }
}