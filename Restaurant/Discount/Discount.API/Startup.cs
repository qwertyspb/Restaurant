using Discount.API.Services;
using Discount.Application.Handlers;
using Discount.Application.Mappers;
using Discount.Core.IRepositories;
using Discount.Infrastructure.Repositories;

namespace Discount.API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetCouponHandler>());

        services.AddScoped<ICouponRepository, CouponRepository>();

        services.AddAutoMapper(x => x.AddProfile<MappingProfile>());

        services.AddGrpc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();

        app.UseEndpoints(builder =>
        {
            builder.MapGrpcService<DiscountService>();
            builder.MapGet("/",
                ctx => ctx.Response.WriteAsync(
                    "Communication with gRPC endpoints must be made through a gRPC client."));
        });
    }
}