using AutoMapper;

namespace Discount.Application.Mappers;

public class DiscountMapper
{
    private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        var config = new MapperConfiguration(x =>
        {
            x.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            x.AddProfile<MappingProfile>();
        });

        return config.CreateMapper();
    });

    public static IMapper Mapper = Lazy.Value;
}