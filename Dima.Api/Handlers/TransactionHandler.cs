using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

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

    public async Task<BaseResponse<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction is null)
                return new BaseResponse<Transaction?>(null, 404, "Transação não encontrada!"); 
                    
            transaction.CategoryId = request.CategoryId;
            transaction.Amount = request.Amount;
            transaction.Title = request.Title;
            transaction.Type = request.Type;
            transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
            
            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            
            return new BaseResponse<Transaction?>(transaction);
        }
        catch
        {
            return new BaseResponse<Transaction?>(null, 500, "Não foi possível atualizar a transação.");
        }
    }

    public async Task<BaseResponse<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction is null)
                return new BaseResponse<Transaction?>(null, 404, "Transação não encontrada!"); 
                    
            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();
            
            return new BaseResponse<Transaction?>(transaction);
        }
        catch
        {
            return new BaseResponse<Transaction?>(null, 500, "Não foi possível atualizar a transação.");
        }
    }

    public async Task<BaseResponse<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

           return transaction is null
                ? new BaseResponse<Transaction?>(null, 404, "Transação não encontrada!")
                : new BaseResponse<Transaction?>(transaction);    
        }
        catch
        {
            return new BaseResponse<Transaction?>(null, 500, "Não foi possível atualizar a transação.");
        }
    }

    public Task<PagedResponse<List<Transaction?>>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}