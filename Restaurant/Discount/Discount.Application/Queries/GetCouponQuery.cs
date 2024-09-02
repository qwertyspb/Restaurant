using Discount.Application.Responses;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Queries;

public class GetCouponQuery : IRequest<GetCouponResponse>
{
    public string Code { get; set; }
}