using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Lingvo.Application.Auth;
using Lingvo.Application.Common;
using Lingvo.Domain.Auth;

namespace Lingvo.API.Configurations;

public static class AuthConfig
{
    public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserSession, UserSession>();

        var tokenConfig = configuration.GetSection("TokenConfig");
        services.Configure<TokenConfig>(tokenConfig);

        var appSettings = tokenConfig.Get<TokenConfig>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Issuer,
                    ValidAudience = appSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


        services.AddAuthorization(options =>
        {
            options.InvokeHandlersAfterFailure = false;
        });

        return services;
    }
}
