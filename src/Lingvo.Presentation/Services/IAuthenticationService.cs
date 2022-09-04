using Lingvo.Presentation.Models;

namespace Lingvo.Presentation.Services;

public interface IAuthenticationService
{
    User User { get; }
    Task Initialize();
    Task Login(string username, string password);
    Task Logout();
}
