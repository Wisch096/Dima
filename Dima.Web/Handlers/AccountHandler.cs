using System.Net.Http.Json;
using Dima.Core.Handlers;
using Dima.Core.Requests.Account;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<BaseResponse<string>> LoginAsync(LoginRequest request)
    {
        await _client.PostAsJsonAsync("v1/identity/login", request);
    }

    public Task<BaseResponse<string>> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}