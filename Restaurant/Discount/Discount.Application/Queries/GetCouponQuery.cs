using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Queries;

public class GetCouponQuery : IRequest<CouponModel>
{
    public string Code { get; set; }
}