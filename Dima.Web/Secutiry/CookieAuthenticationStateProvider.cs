using Microsoft.AspNetCore.Components.Authorization;

namespace Dima.Web.Secutiry;

public class CookieAuthenticationStateProvider(IHttpClientFactory httpClientFactory) : AuthenticationStateProvider, ICookieAuthenticationStateProvider
{
    private bool _isAuthenticated = false;
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<bool> CheckAuthenticatedAsync()
    {
        await GetAuthenticationStateAsync();
        return _isAuthenticated;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }

    public void NotifyAuthenticationStateChanged() => base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}