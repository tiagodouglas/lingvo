using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Lingvo.API.Configurations;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Lingvo.API",
                    Version = "v1",
                    Description = "API Lingvo",
                    Contact = new OpenApiContact
                    {
                        Name = "Tiago Douglas",
                        Url = new Uri("https://github.com/tiagodouglas")
                    }        
                });
            c.DescribeAllParametersInCamelCase();
            c.OrderActionsBy(x => x.RelativePath);

            var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }

            c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            c.OperationFilter<SecurityRequirementsOperationFilter>();

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your valid token.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFNpc3RlbWEiOjIsImlkQ2FuYWxWZW5kYSI6bnVsbCwiaWF0IjoxNjYxOTY4MDc4fQ",
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.List);
                c.DisplayRequestDuration();
            });
        return app;
    }
}
