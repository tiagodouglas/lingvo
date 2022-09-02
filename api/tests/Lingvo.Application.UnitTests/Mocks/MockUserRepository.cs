using Moq;
using Lingvo.Domain.Users;

namespace Lingvo.Application.UnitTests.Mocks;

public static class MockUserRepository
{
    public static Mock<IUserRepository> GetUserRepository()
    {
        var userEmail = "newuser@test.com";
        var users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                Name = "New user",
                Email = userEmail,
                Password = "test123",
                DateCreated = DateTime.Now,
                DateUpdated = null
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "New user 2",
                Email = "newuser2@test.com",
                Password = "test123",
                DateCreated = DateTime.Now,
                DateUpdated = null
            }
        };

        var mockRepo = new Mock<IUserRepository>();

        mockRepo.Setup(r => r.CreateUser(It.IsAny<User>())).Callback((User user) =>
        {
            users.Add(user);
        });
        mockRepo
            .Setup(r => r.VerifyIfUserExists(userEmail))
            .ReturnsAsync(users.Any(x => x.Email == userEmail));

        return mockRepo;
    }
}
