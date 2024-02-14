using Discount.Core.Entities;

namespace Discount.Core.IRepositories;

public interface ICouponRepository
{
    Task<Coupon> GetCoupon(string code);
    Task CreateCoupon(Coupon coupon);
    Task UpdateCoupon(Coupon coupon);
}