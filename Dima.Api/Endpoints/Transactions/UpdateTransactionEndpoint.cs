﻿using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Transaction: Update")
            .WithSummary("Atualiza uma transação")
            .WithDescription("Atualiza uma transação")
            .WithOrder(2)
            .Produces<BaseResponse<Transaction>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler, 
        UpdateTransactionRequest request, 
        long id)
    {
        request.UserId = "matheus@gmail.com";
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result.Data) 
            : TypedResults.BadRequest(result.Data);
    }
}