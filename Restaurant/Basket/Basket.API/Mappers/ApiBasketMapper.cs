﻿using AutoMapper;

namespace Basket.API.Mappers;

public class ApiBasketMapper
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