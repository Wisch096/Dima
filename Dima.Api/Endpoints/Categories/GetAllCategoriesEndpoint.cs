﻿using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: GetAll")
            .WithSummary("Recupera todas as categoria")
            .WithDescription("Recupera todas as categoria")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category?>>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler, 
        int pageNumber = Configuration.DefaultPageNumber, 
        int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = "matheus@gmail.com",
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result.Data) 
            : TypedResults.BadRequest(result.Data);
    }
}