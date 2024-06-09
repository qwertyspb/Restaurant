using Dapper;
using Discount.Core.Entities;
using Discount.Core.IRepositories;
using Microsoft.Extensions.Configuration;
using Npgsql;
using DateTime = System.DateTime;

namespace Discount.Infrastructure.Repositories;

public class CouponRepository : ICouponRepository, IDisposable
{
    private readonly NpgsqlConnection _connection;

    public CouponRepository(IConfiguration configuration)
    {
        _connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    }

    public async Task<Coupon?> GetCoupon(string code)
    {
        var coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM Coupon WHERE Code = @Code", new { Code = code });

        return coupon;
    }

    public async Task<bool> CreateCoupon(Coupon coupon)
    {
        var affected = await _connection.ExecuteAsync
        ("INSERT INTO Coupon (Code, Description, Percent, ExpirationDate, CreatedOn) VALUES (@Code, @Description, @Percent, @ExpirationDate, @CreatedOn)",
            new
            {
                coupon.Code,
                coupon.Description,
                coupon.Percent,
                coupon.ExpirationDate,
                CreatedOn = DateTime.Now
            });

        return affected is not 0;
    }

    public async Task<bool> UpdateCoupon(Coupon coupon)
    {
        var affected = await _connection.ExecuteAsync
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

        return affected is not 0;
    }

    public async Task<bool> DeleteCoupon(string code)
    {
        var affected = await _connection.ExecuteAsync("DELETE FROM Coupon WHERE Code = @Code",
            new { Code = code });

        return affected is not 0;
    }

    public void Dispose()
        => _connection.Dispose();
}