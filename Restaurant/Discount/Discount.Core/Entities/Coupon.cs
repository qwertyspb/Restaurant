namespace Discount.Core.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
    public int Percent { get; set; }
    public DateTime ExpirationDate { get; set; }
}