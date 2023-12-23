using AutoMapper;

namespace Catalog.API.Mappers
{
    public class ApiCatalogMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(x =>
            {
                x.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                x.AddProfile<ApiMappingProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper = Lazy.Value;
    }
}
