using Dapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneOf;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lingvo.Application.Common;
using Lingvo.Application.Common.Responses;
using Lingvo.Application.Users;
using Lingvo.Domain.Common;
using Lingvo.Domain.Users;
using BC = BCrypt.Net.BCrypt;

namespace Lingvo.Application.Auth.Authenticate;

public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, OneOf<Jwt?, UserBadRequest>>
{
    private IDatabaseConnection _db;
    private readonly IUserRepository _userRepository;
    private readonly TokenConfig _tokenConfig;

    public AuthenticateHandler(IUnitOfWork unitOfWork, IOptions<TokenConfig> tokenConfig, IUserRepository userRepository)
    {
        _db = unitOfWork.Get();
        _tokenConfig = tokenConfig.Value;
        _userRepository = userRepository;
    }

    public async Task<OneOf<Jwt?, UserBadRequest>> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);

        if (user is null || !BC.Verify(request.Password, user.Password))
        {
            return new UserBadRequest("Email or Password is invalid ");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenConfig.Secret);
        var claims = new ClaimsIdentity(new Claim[]
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
        });

        var expDate = DateTime.UtcNow.AddHours(1);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = expDate,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _tokenConfig.Audience,
            Issuer = _tokenConfig.Issuer
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new Jwt
        {
            Token = tokenHandler.WriteToken(token),
            ExpDate = expDate,
            Name = user.Name,
            Email = user.Email,
            Id = user.Id
        };
    }
}
