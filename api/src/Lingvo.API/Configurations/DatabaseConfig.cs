using System.Data.SqlClient;
using Lingvo.Domain.Common;
using Lingvo.Infrastructure.Database;

namespace Lingvo.API.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped(x => new DatabaseConnection(new SqlConnection(configuration
                .GetConnectionString("db_lingvo"))));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
