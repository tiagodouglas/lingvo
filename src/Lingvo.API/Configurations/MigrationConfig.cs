using Npgsql;
using System.Data.SqlClient;

namespace Lingvo.API.Configurations;

public static class MigrationConfig
{
    public static void Migrate(IConfiguration configuration, ILogger logger)
    {
        try
        {
            var cnx = new NpgsqlConnection(configuration.GetConnectionString("db_lingvo"));
            var evolve = new Evolve.Evolve(cnx, msg => logger.LogInformation(msg))
            {
                Locations = new[] { configuration["Evolve:Location"] },
                IsEraseDisabled = true,
                MetadataTableName = "Migrations",
            };

            evolve.Migrate();

        } catch(Exception ex)
        {
            logger.LogCritical("Database migration failed.", ex);
            throw;
        }
    }
}
