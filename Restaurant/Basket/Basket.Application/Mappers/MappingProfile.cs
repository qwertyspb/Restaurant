using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Dto;
using Basket.Application.Responses;
using Basket.Core.Entities;

namespace Basket.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cart, CartResponse>();

        CreateMap<CartItem, CartItemDto>()
            .ReverseMap();

        CreateMap<CreateOrUpdateCartCommand, Cart>();
    }
}