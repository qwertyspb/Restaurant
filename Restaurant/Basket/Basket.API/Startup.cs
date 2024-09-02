using Basket.API.Mappers;
using Basket.Application.Handlers;
using Basket.Application.Mappers;
using Basket.Application.Services;
using Basket.Core.IRepositories;
using Basket.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace Basket.API;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddApiVersioning();

        // Redis
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
        });

        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<AddProductsToCartHandler>());

        services.AddAutoMapper(x =>
        {
            x.AddProfile<MappingProfile>();
            x.AddProfile<ApiMappingProfile>();
        });

        services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Basket.API",
            Version = "v1"
        }));

        services.AddHealthChecks()
            .AddRedis(Configuration["CacheSettings:ConnectionString"], "Redis Health", HealthStatus.Degraded);

        services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
            x => x.Address = new Uri(Configuration["GrpcSettings:DiscountUrl"]));

        
        services.AddSingleton<ICartRepository, CartRepository>();
        services.AddScoped<GrpcDiscountService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket. API v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        });
    }
}