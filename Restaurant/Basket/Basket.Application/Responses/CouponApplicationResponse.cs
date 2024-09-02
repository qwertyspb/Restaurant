namespace Basket.Application.Responses;

public class CouponApplicationResponse
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public decimal? TotalPrice { get; set; }
}