using AutoMapper;
using Discount.Core.Entities;
using Discount.Grpc.Protos;

namespace Discount.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Coupon, CouponModel>();
    }
}