using Discount.Application.Extensions;
using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Application.Validators;
using Discount.Core.IRepositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetCouponHandler : IRequestHandler<GetCouponQuery, CouponModel>
{
    private readonly ICouponRepository _repo;

    public GetCouponHandler(ICouponRepository repo)
    {
        _repo = repo;
    }

    public async Task<CouponModel> Handle(GetCouponQuery request, CancellationToken cancellationToken)
    {
        request.Validate(new GetCouponQueryValidator());

        var coupon = await _repo.GetCoupon(request.Code)
                     ?? throw new RpcException(new Status(StatusCode.NotFound,
                         $"Coupon code={request.Code} is not found"));

        return DiscountMapper.Mapper.Map<CouponModel>(coupon);
    }
}