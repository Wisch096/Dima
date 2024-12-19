using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<BaseResponse<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        try
        {
            var transaction = new Transaction
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.Now,
                Amount = request.Amount,
                PaidOrReceivedAt = request.PaidOrReceivedAt,
                Title = request.Title,
                Type = request.Type,
            };
        
            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();
        
            return new BaseResponse<Transaction?>(transaction, 201, "Transação criada com sucesso!");
        }
        catch
        {
            return new BaseResponse<Transaction?>(null, 500, "Não foi possível criar a sua transação!");
        }
    }

    public Task<BaseResponse<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Transaction?>>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}