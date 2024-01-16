using Basket.Core.Entities;
using Basket.Core.IRepositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IDistributedCache _redisCache;

    public CartRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache;
    }
    public async Task<Cart?> GetCart(string userName)
    {
        var cart = await _redisCache.GetStringAsync(userName);

        return string.IsNullOrEmpty(cart)
            ? null 
            : JsonConvert.DeserializeObject<Cart>(cart);
    }

    public Task CreateOrUpdateCart(Cart cart)
        => _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));

    public Task DeleteCart(string userName)
       => _redisCache.RemoveAsync(userName);
}