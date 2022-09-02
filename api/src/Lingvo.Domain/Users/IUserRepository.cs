using System.Threading.Tasks;

namespace Lingvo.Domain.Users
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<bool> VerifyIfUserExists(string email);
    }
}
