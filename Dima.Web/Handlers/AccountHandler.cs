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
        var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
        return result.IsSuccessStatusCode
            ? new BaseResponse<string>("Login realizado com sucesso!", 200, "Login realizado com sucesso!")
            : new BaseResponse<string>(null, 400, "Não foi possível realizar o login.");
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