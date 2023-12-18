using AutoMapper;
using Catalog.API.Models;
using Catalog.Application.Commands;
using Catalog.Application.Responses;

namespace Catalog.API.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<ProductModel, ProductApiModel>();
            CreateMap<CategoryModel, CategoryApiModel>();
            CreateMap<CreateProductApiModel, CreateProductCommand>();
            CreateMap<UpdateProductApiModel, UpdateProductCommand>();
        }
    }
}
