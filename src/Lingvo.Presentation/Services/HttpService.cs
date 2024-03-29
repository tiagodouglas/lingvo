﻿using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Lingvo.Presentation.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Lingvo.Presentation.Services;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;
    private readonly IConfiguration _configuration;
    private readonly IMatToaster _toastService;

    public HttpService(
        HttpClient httpClient,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService,
        IConfiguration configuration,
        IMatToaster toastService
    )
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
        _configuration = configuration;
        _httpClient.BaseAddress = new Uri(_configuration["apiUrl"]);
        _toastService = toastService;
    }

    public async Task<T> Get<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        return await sendRequest<T>(request);
    }

    public async Task<T> Post<T>(string uri, object value)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        return await sendRequest<T>(request);
    }

    private async Task<T?> sendRequest<T>(HttpRequestMessage request)
    {
        var user = await _localStorageService.GetItemAsync<User>("user");
        var isApiUrl = !request.RequestUri.IsAbsoluteUri;
        if (user != null && isApiUrl)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

        using var response = await _httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _navigationManager.NavigateTo("login");
            return default;
        }

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            _toastService.Add(error["message"], MatToastType.Danger);

            return default;
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }
}
