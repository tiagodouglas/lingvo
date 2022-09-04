using MassTransit;
using MassTransit.NewIdProviders;
using Lingvo.Application.MappingProfiles;

namespace Lingvo.API.Configurations;

public static class ApplicationConfig
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        NewId.SetProcessIdProvider(new CurrentProcessIdProvider());

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddCors(options =>
        {
            options.AddPolicy("CorsApi",
                builder => builder.WithOrigins("https://localhost:7260", "http://localhost:5260")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
        return services;
    }
}
