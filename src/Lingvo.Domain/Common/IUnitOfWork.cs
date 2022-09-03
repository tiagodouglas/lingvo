namespace Lingvo.Domain.Common;

public interface IUnitOfWork
{
    IDatabaseConnection Get();
}
