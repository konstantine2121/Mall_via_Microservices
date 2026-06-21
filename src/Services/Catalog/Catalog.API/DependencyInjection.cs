using Asp.Versioning;
using Catalog.Application.Queries.BrandQueries;
using Microsoft.OpenApi.Models;

namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            // 1.0
            options.DefaultApiVersion = new ApiVersion(1,0);
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";// v1
            options.SubstituteApiVersionInUrl = true;
        });
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Catalog API",
                Version = "v1",
            });
            
            config.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Catalog API",
                Version = "v2",
            });
            
            config.EnableAnnotations();
            
            var baseDirectory = AppContext.BaseDirectory;
            config.IncludeXmlComments(Path.Combine(baseDirectory, "Catalog.Domain.xml"));
        });
        
        //var assembly = typeof(GetBrandsQuery).Assembly;
        var assembly = typeof(Application.DependencyInjection).Assembly;
        var licenseKey = configuration.GetSection("MediatR:LicenseKey").Value;

        services.AddMediatR(config =>
        {
            config.LicenseKey = licenseKey;
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
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "Catalog API v2");
            }
            );
        }
        
        return app;
    }
}