using AutoMapper;
using Lingvo.Application.Users;
using Lingvo.Application.Users.CreateUser;
using Lingvo.Domain.Users;

namespace Lingvo.Application.MappingProfiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // User Map
        CreateMap<User, UserResponse>().ReverseMap();
        CreateMap<CreateUserRequest, User>();
    }
}
