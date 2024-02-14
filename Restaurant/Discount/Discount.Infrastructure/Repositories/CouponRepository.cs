using Dapper;
using Discount.Core.Entities;
using Discount.Core.IRepositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly IConfiguration _configuration;

    public CouponRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Coupon> GetCoupon(string code)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM Coupon WHERE Code = @Code", new { Code = code });

        return coupon ?? new Coupon { Code = "No such coupon", Percent = 0, Description = "No such coupon" };
    }

    public async Task CreateCoupon(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        await connection.ExecuteAsync
        ("INSERT INTO Coupon (Code, Description, Percent, ExpirationDate, CreatedOn) VALUES (@Code, @Description, @Percent, @ExpirationDate, @CreatedOn)",
            new
            {
                coupon.Code,
                coupon.Description,
                coupon.Percent,
                coupon.ExpirationDate,
                CreatedOn = DateTime.Now
            });
    }

    public async Task UpdateCoupon(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        await connection.ExecuteAsync
        ("UPDATE Coupon SET Code=@Code, Description = @Description, Percent = @Percent, ExpirationDate=@ExpirationDate, ModifiedOn=@ModifiedOn WHERE Id = @Id",
            new
            {
                coupon.Id,
                coupon.Code, 
                coupon.Description,
                coupon.Percent,
                coupon.ExpirationDate,
                ModifiedOn = DateTime.Now
            });
    }
}