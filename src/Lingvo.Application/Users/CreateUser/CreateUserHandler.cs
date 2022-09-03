using AutoMapper;
using MediatR;
using OneOf;
using System.Threading;
using System.Threading.Tasks;
using Lingvo.Domain.Common;
using Lingvo.Domain.Users;
using BC = BCrypt.Net.BCrypt;

namespace Lingvo.Application.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, OneOf<UserResponse?, UserBadRequest>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IDatabaseConnection _db;

    public CreateUserHandler(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _db = unitOfWork.Get();
    }

    public async Task<OneOf<UserResponse?, UserBadRequest>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.VerifyIfUserExists(request.Email.ToLower());

        if (userExists) return new UserBadRequest("Email already exists");

        var created = _mapper.Map<User>(request);
        created.Email = created.Email.ToLower();
        created.Password = BC.HashPassword(request.Password);
        await _userRepository.CreateUser(created);
        _db.Commit();

        return _mapper.Map<UserResponse?>(created);
    }
}
