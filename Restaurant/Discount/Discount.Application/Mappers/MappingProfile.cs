using AutoMapper;
using Discount.Application.Responses;
using Discount.Core.Entities;

namespace Discount.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Coupon, GetCouponResponse>();
    }
}