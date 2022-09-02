using MediatR;
using OneOf;
using Lingvo.Application.Common.Responses;
using Lingvo.Application.Users;

namespace Lingvo.Application.Auth.Authenticate
{
    public record AuthenticateRequest: IRequest<OneOf<Jwt?, UserBadRequest>>
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
