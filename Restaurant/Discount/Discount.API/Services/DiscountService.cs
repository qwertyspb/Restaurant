using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<DiscountService> _logger;

    public DiscountService(IMediator mediator, ILogger<DiscountService> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public override async Task<CouponModel> GetCoupon(GetCouponRequest request, ServerCallContext context)
    {
        var query = new GetCouponQuery { Code = request.Code };
        var result = await _mediator.Send(query);

        _logger.LogInformation($"Coupon is retrieved for the Coupon Code={request.Code}");

        return result;
    }
}