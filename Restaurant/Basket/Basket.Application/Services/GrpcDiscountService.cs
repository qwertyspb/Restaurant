using Discount.Grpc.Protos;

namespace Basket.Application.Services;

public class GrpcDiscountService
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _client;

    public GrpcDiscountService(DiscountProtoService.DiscountProtoServiceClient client)
    {
        _client = client;
    }

    public async Task<CouponModel> GetCoupon(string code)
    {
        var request = new GetCouponRequest { Code = code };
        return await _client.GetCouponAsync(request);
    }
}