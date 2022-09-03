using MediatR;
using System.Reflection;
using Lingvo.Application.Common;
using Lingvo.Application.Common.Behaviors;
using Lingvo.Application.Common.Handlers;

namespace Lingvo.API.Configurations;

public static class MediatRConfig
{
    public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Application.IAssemblyMarker).GetTypeInfo().Assembly);

        services.AddScoped<INotificationHandler<ValidationError>, ValidationErrorHandler>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;

    }
}
