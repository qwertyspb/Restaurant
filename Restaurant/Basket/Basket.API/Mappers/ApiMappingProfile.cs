using AutoMapper;
using Basket.API.Models;
using Basket.Application.Commands;
using Basket.Application.Dto;
using Basket.Application.Responses;

namespace Basket.API.Mappers;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<ProductItemApiModel, ProductItemDto>()
            .ReverseMap();

        CreateMap<CartResponse, GetCartApiModel>();

        CreateMap<CreateCartResponse, CreateCartApiResponse>();

        CreateMap<AddProductsToCartApiModel, AddProductsToCartCommand>();

        CreateMap<TableItemDto, TableItemApiModel>();
    }
}