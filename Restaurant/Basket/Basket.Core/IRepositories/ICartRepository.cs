﻿using Basket.Core.Entities;

namespace Basket.Core.IRepositories;

public interface ICartRepository
{
    Task<Cart?> GetCart(string userName);
    Task CreateOrUpdateCart(Cart cart, TimeSpan? ttl);
    Task DeleteCart(string userName);
}