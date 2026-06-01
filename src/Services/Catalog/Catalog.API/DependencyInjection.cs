using Catalog.Application.Queries.BrandQueries;

namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        //var assembly = typeof(GetBrandsQuery).Assembly;
        var assembly = typeof(Application.DependencyInjection).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });
        
        return services;
    }

    public static WebApplication UseApiServices(
        this WebApplication app)
    {
        app.MapControllers();
        // if (app.Environment.IsDevelopment()) //Uncomment when production build will be ready
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGet("/", () => "Hello World!");
        
        return app;
    }
}