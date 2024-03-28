using Discount.Core.Entities;

namespace Discount.Core.IRepositories;

public interface ICouponRepository
{
    Task<Coupon> GetCoupon(string code);
    Task<bool> CreateCoupon(Coupon coupon);
    Task<bool> UpdateCoupon(Coupon coupon);
    Task<bool> DeleteCoupon(string code);
}