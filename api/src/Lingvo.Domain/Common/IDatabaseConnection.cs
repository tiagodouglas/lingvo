using System;
using System.Data;

namespace Lingvo.Domain.Common
{
    public interface IDatabaseConnection : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Commit();
        void Rollback();
    }
}
