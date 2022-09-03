using AutoMapper;
using Lingvo.Application.MappingProfiles;
using Lingvo.Application.UnitTests.Mocks;
using Lingvo.Application.Users;
using Lingvo.Application.Users.CreateUser;
using Lingvo.Domain.Common;
using Lingvo.Domain.Users;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Lingvo.Application.UnitTests.Users;

[TestFixture]
public class CreateUserHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IUnitOfWork> _db;


    public CreateUserHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _userRepository = new Mock<IUserRepository>();
        _db = MockUnitOfWork.GetUnitOfWork();
    }

    [Test]
    public async Task CreateUser_ShouldReturnUserCreated()
    {
        var handler = new CreateUserHandler(_mapper, _userRepository.Object, _db.Object);

        var result = await handler.Handle(new CreateUserRequest
        {
            Name = "Test",
            Email = "teste@email.com",
            Password = "1234"
        }, CancellationToken.None);

        result.AsT0.ShouldBeOfType<UserResponse>();
        result.AsT0.ShouldNotBeNull();
    }
}
