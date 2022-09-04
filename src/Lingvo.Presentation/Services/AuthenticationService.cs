using Blazored.LocalStorage;
using Lingvo.Presentation.Models;
using Microsoft.AspNetCore.Components;

namespace Lingvo.Presentation.Services;

public class AuthenticationService : IAuthenticationService
{
    private IHttpService _httpService;
    private NavigationManager _navigationManager;
    private ILocalStorageService _localStorageService;

    public User User { get; private set; }

    public AuthenticationService(
        IHttpService httpService,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService
    )
    {
        _httpService = httpService;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    public async Task Initialize()
    {
        User = await _localStorageService.GetItemAsync<User>("user");
    }

    public async Task Login(string email, string password)
    {
        User = await _httpService.Post<User>("api/user/authenticate", new { email, password });
        await _localStorageService.SetItemAsync("user", User);

        if (User != null)
        {
            _navigationManager.NavigateTo("/");
        }
    }

    public async Task Logout()
    {
        User = null;
        await _localStorageService.RemoveItemAsync("user");
        _navigationManager.NavigateTo("login");
    }
}
