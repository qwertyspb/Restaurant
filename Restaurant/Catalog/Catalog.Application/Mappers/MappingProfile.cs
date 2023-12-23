using AutoMapper;
using Catalog.Application.Helpers.SearchHelper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<Product, ProductModel>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Pagination<Product>, Pagination<ProductModel>>();
        }
    }
}
