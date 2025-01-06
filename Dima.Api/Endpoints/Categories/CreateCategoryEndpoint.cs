using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("Cria uma nova categoria")
            .WithOrder(1)
            .Produces<BaseResponse<Category>>();
    
    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        [FromBody] CreateCategoryRequest request)
    {
        request.UserId = "matheus@gmail.com";
        var result = await handler.CreateAsync(request);
        return result.IsSuccess 
            ? TypedResults.Created($"/{result.Data?.Id}", result.Data) 
            : TypedResults.BadRequest(result.Data);
    }
}