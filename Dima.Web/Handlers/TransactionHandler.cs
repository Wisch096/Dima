using System.Net.Http.Json;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<BaseResponse<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/transactions", request);
        return await result.Content.ReadFromJsonAsync<BaseResponse<Transaction?>>()
            ?? new BaseResponse<Transaction?>(null, 400, "Não foi possível criar sua transação");
    }

    public async Task<BaseResponse<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/transactions/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<BaseResponse<Transaction?>>()
               ?? new BaseResponse<Transaction?>(null, 400, "Não foi possível atualizar sua transação");
    }

    public async Task<BaseResponse<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var result = await _client.DeleteAsync($"v1/transactions/{request.Id}");
        return await result.Content.ReadFromJsonAsync<BaseResponse<Transaction?>>()
               ?? new BaseResponse<Transaction?>(null, 400, "Não foi possível excluir sua transação");
    }

    public async Task<BaseResponse<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        return await _client.GetFromJsonAsync<BaseResponse<Transaction?>>($"v1/transactions/{request.Id}") 
               ?? new BaseResponse<Transaction?>(null, 400, "Não foi possível obter a transação");
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}