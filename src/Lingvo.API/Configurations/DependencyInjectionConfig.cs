using Lingvo.Domain.Languages;
using Lingvo.Domain.Lessons;
using Lingvo.Domain.Users;
using Lingvo.Infrastructure.Domain.Languages;
using Lingvo.Infrastructure.Domain.Lessons;
using Lingvo.Infrastructure.Domain.Users;

namespace Lingvo.API.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();

        return services;
    }
}
