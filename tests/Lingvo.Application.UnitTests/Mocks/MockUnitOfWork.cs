using Moq;
using Lingvo.Domain.Common;

namespace Lingvo.Application.UnitTests.Mocks;

public static class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mock = new Mock<IUnitOfWork>();
        var uowMock = new Mock<IDatabaseConnection>();

        uowMock.Setup(x => x.Commit()).Callback(() => { });

        mock.Setup(x => x.Get()).Returns(uowMock.Object);
      
        return mock;
    }
}
