using Lingvo.Application.Auth.Authenticate;
using Lingvo.Application.Common;
using Lingvo.Application.Common.Responses;
using Lingvo.Application.UnitTests.Mocks;
using Lingvo.Domain.Common;
using Lingvo.Domain.Users;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lingvo.Application.UnitTests.Auth;

[TestFixture]
public class AuthenticateHandlerTests
{
    private Mock<IUnitOfWork> _unitOfWork;
    private readonly IOptions<TokenConfig> _tokenConfig;
    private readonly Mock<IUserRepository> _userRepository;

    public AuthenticateHandlerTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();

        var tokenConfig = new TokenConfig()
        {
            Secret = "test123",
            Issuer = "test123",
            Audience = "test123"
        };

        _tokenConfig = Options.Create(tokenConfig);
        _userRepository = MockUserRepository.GetUserRepository();
    }

    [Test]
    public async Task Authenticate_ShouldReturnToken()
    {
        var handler = new AuthenticateHandler(_unitOfWork.Object, _tokenConfig, _userRepository.Object);

        var result = await handler.Handle(new AuthenticateRequest
        {
            Email = "newuser@test.com",
            Password = "test123"
        }, CancellationToken.None);

        result.AsT0.ShouldBeOfType<Jwt>();
        result.AsT0.ShouldNotBeNull();
    }

}
