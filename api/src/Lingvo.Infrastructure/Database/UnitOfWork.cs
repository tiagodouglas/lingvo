using Lingvo.Domain.Common;

namespace Lingvo.Infrastructure.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDatabaseConnection _dbConnection;

    public UnitOfWork(DatabaseConnection databaseConnection)
    {
        _dbConnection = databaseConnection;
    }

    public IDatabaseConnection Get()
    {
        return _dbConnection;
    }
}
