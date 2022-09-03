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

        return services;
    }
}
