using Basket.Application.Commands;
using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class ApplyCouponQuery : UserNameBasedRequest, IRequest<CouponApplicationResponse>
{
    public string Code { get; set; }
}