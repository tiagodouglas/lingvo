using AutoMapper;
using Lingvo.Application.Lessons;
using Lingvo.Application.Lessons.CreateLesson;
using Lingvo.Application.Users;
using Lingvo.Application.Users.CreateUser;
using Lingvo.Domain.Lessons;
using Lingvo.Domain.Users;
using System.Collections;

namespace Lingvo.Application.MappingProfiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // User Map
        CreateMap<User, UserResponse>().ReverseMap();
        CreateMap<CreateUserRequest, User>();

        // Lesson Map
        CreateMap<Lesson, LessonResponse>().ReverseMap();
        CreateMap<CreateLessonRequest, Lesson>().ReverseMap();
    }
}
