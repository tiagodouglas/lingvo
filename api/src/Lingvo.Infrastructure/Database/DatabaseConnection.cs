using System;
using System.Data;
using Lingvo.Domain.Common;

namespace Lingvo.Infrastructure.Database;

public class DatabaseConnection: IDisposable, IDatabaseConnection
{
    public IDbConnection Connection { get; }

    public IDbTransaction Transaction { get; }

    public DatabaseConnection(IDbConnection connection)
    {
        Connection = connection;

        connection.Open();

        Transaction = connection.BeginTransaction();
    }

    public void Commit()
    {
        Transaction.Commit();

        Dispose();
    }

    public void Rollback()
    {
        Transaction.Rollback();

        Dispose();
    }

    public void Dispose()
    {
        Transaction.Dispose();

        Connection.Dispose();
    }
}
