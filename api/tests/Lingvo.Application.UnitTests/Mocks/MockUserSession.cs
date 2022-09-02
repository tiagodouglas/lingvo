using Moq;
using Lingvo.Domain.Auth;

namespace Lingvo.Application.UnitTests.Mocks
{
    public static class MockUserSession
    {
        public static Mock<IUserSession> GetUserSession()
        {
            var mockSession = new Mock<IUserSession>();

            mockSession.SetupGet(x => x.UserId).Returns(Guid.Parse("41d48f34-8407-4bca-b75b-1d14b41c07d1"));

            return mockSession;
        }
    }
}
