using MediatR;
using OneOf;

namespace Lingvo.Application.Users.CreateUser
{
    public record CreateUserRequest: IRequest<OneOf<UserResponse?, UserBadRequest>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
