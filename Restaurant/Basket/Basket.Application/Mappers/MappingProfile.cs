using AutoMapper;
using Basket.Application.Responses;
using Basket.Core.Entities;

namespace Basket.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResponse>();
        CreateMap<CartItem, CartItemResponse>();
    }
}