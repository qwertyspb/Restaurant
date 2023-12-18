using AutoMapper;
using Catalog.API.Mappers;
using Catalog.Application.Mappers;
using NUnit.Framework;

namespace Catalog.Test
{
    [TestFixture]
    public class AutoMapperTests
    {
        private readonly MapperConfiguration _configuration;

        public AutoMapperTests()
        {
            _configuration = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
                x.AddProfile<ApiMappingProfile>();
            });
        }

        [Test]
        public void AssertMappingConfigurationIsValid()
            => _configuration.AssertConfigurationIsValid();
    }
}