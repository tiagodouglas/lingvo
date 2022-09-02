using Lingvo.Domain.Users;
using Lingvo.Infrastructure.Domain.Users;

namespace Lingvo.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
