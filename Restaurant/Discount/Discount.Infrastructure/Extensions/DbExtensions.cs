using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.Infrastructure.Extensions;

public static class DbExtensions
{
    public static IHost MigrateDatabase<TContext>(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var config = services.GetRequiredService<IConfiguration>();
        var logger = services.GetRequiredService<ILogger<TContext>>();

        try
        {
            logger.LogInformation("Discount DB Migration started");
            ApplyMigrations(config);
            logger.LogInformation("Discount DB Migration completed");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

        return host;
    }

    private static void ApplyMigrations(IConfiguration config)
    {
        var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
        connection.Open();

        using var cmd = new NpgsqlCommand { Connection = connection };

        cmd.CommandText = "DROP TABLE IF EXISTS Coupon";
        cmd.ExecuteNonQuery();

        cmd.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY_KEY, 
                                                Code VARCHAR(20) NOT NULL UNIQUE,
                                                Description TEXT,
                                                Percent INT CHECK (Percent >= 1 AND Percent <= 100),
                                                ExpirationDate TIMESTAMP,
                                                CreatedOn TIMESTAMP,
                                                ModifiedOn TIMESTAMP)";
        cmd.ExecuteNonQuery();

        cmd.CommandText =
            "INSERT INTO Coupon (Code, Description, Percent, ExpirationDate, CreatedOn) " +
            "VALUES (BIRTHDAY, Coupon for birthday, 10, '9999-12-31', CURRENT_TIMESTAMP)";
        cmd.ExecuteNonQuery();
    }
}