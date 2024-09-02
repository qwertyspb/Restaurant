namespace Discount.Application.Responses;

public class GetCouponResponse
{
    public DateTime ExpirationDate { get; set; }
    public int Percent { get; set; }
}