using AutoMapper;
using Discount.Application.Extensions;
using Discount.Application.Responses;
using Discount.Grpc.Protos;

namespace Discount.API.Mappers;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<GetCouponResponse, CouponModel>()
            .ForMember(dst => dst.ExpirationDate,
                opt => opt.MapFrom(src => src.ExpirationDate.ToTimestamp()))
            .ForMember(dst => dst.IsNull, opt => opt.MapFrom(_ => false));
    }
}   