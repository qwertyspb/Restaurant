﻿using Basket.Core.Entities;
using Basket.Core.IRepositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache;
    }
    public async Task<ShoppingCart> GetBasket(string userName)
    {
        var basket = await _redisCache.GetStringAsync(userName);

        return string.IsNullOrEmpty(basket)
            ? null 
            : JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
    {
        await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
        return await GetBasket(cart.UserName);
    }

    public Task DeleteBasket(string userName)
       => _redisCache.RemoveAsync(userName);
}