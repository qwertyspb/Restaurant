using Discount.Application.Extensions;
using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Application.Responses;
using Discount.Application.Validators;
using Discount.Core.IRepositories;
using MediatR;

namespace Discount.Application.Handlers;

public class GetCouponHandler : IRequestHandler<GetCouponQuery, GetCouponResponse>
{
    private readonly ICouponRepository _repo;

    public GetCouponHandler(ICouponRepository repo)
    {
        _repo = repo;
    }

    public async Task<GetCouponResponse> Handle(GetCouponQuery request, CancellationToken cancellationToken)
    {
        request.Validate(new GetCouponQueryValidator());

        var coupon = await _repo.GetCoupon(request.Code.ToUpper());

        return DiscountMapper.Mapper.Map<GetCouponResponse>(coupon);
    }
}