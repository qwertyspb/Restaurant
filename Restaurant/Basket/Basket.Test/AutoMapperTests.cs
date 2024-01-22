using AutoMapper;
using Basket.API.Mappers;
using Basket.Application.Mappers;
using NUnit.Framework;

namespace Basket.Test;

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