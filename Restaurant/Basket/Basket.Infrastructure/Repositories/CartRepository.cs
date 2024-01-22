using Basket.Core.Entities;
using Basket.Core.IRepositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IDistributedCache _redisCache;
    private readonly DistributedCacheEntryOptions _options;

    public CartRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache;
        _options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
        };
    }
    public async Task<Cart?> GetCart(string userName)
    {
        var cart = await _redisCache.GetStringAsync(userName);

        return string.IsNullOrEmpty(cart)
            ? null 
            : JsonConvert.DeserializeObject<Cart>(cart);
    }

    public async Task CreateOrUpdateCart(Cart cart, TimeSpan? ttl)
    {
        if (ttl is not null)
            _options.AbsoluteExpirationRelativeToNow = ttl;

        await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart), _options);
    }

    public Task DeleteCart(string userName)
       => _redisCache.RemoveAsync(userName);
}