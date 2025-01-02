﻿using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface ITransactionHandler
{
    Task<BaseResponse<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<BaseResponse<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
    Task<BaseResponse<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
    Task<BaseResponse<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodRequest request);
}