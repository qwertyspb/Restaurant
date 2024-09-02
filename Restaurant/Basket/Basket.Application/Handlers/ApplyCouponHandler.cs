using Basket.Application.Extensions;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Application.Services;
using Basket.Application.Validators;
using Basket.Core.Entities;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class ApplyCouponHandler : IRequestHandler<ApplyCouponQuery, CouponApplicationResponse>
{
    private readonly GrpcDiscountService _discountSrv;
    private readonly ICartRepository _repo;

    public ApplyCouponHandler(GrpcDiscountService discountSrv, ICartRepository repo)
    {
        _discountSrv = discountSrv;
        _repo = repo;
    }

    public async Task<CouponApplicationResponse> Handle(ApplyCouponQuery request, CancellationToken cancellationToken)
    {
        request.Validate(new ApplyCouponQueryValidator());

        var coupon = await _discountSrv.GetCoupon(request.Code);

        if (coupon.IsNull)
            return new CouponApplicationResponse
            {
                IsSuccess = false,
                ErrorMessage = $"Coupon with code {request.Code} does not exist."
            };

        var cart = await _repo.GetCart(request.UserName) ??
                   throw new Exception($"Cart for user {request.UserName} does not exist.");

        var expirationDate = coupon.ExpirationDate.ToDateTime().ToLocalTime();

        if (cart.TableItem.BookingStartDate > expirationDate)
            return new CouponApplicationResponse
            {
                IsSuccess = false,
                ErrorMessage =
                    $"Coupon code {request.Code} is not applicable to your reservation date {cart.TableItem.BookingStartDate}."
            };

        var reducedPrice = CalculateReducedPrice(cart.ProductItems, coupon.Percent);

        return new CouponApplicationResponse
        {
            IsSuccess = true,
            TotalPrice = reducedPrice
        };
    }

    private static decimal CalculateReducedPrice(IEnumerable<ProductItem> products, int percent)
    {
        var totalPrice = products.Select(x => x.Price * x.Quantity).Sum();
        var reducedPrice = totalPrice * (1 - percent / 100m);
        return reducedPrice;
    }
}