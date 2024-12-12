using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Exclui uma categoria")
            .WithDescription("Exclui uma categoria")
            .WithOrder(2)
            .Produces<BaseResponse<Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler, long id)
    {
        var request = new DeleteCategoryRequest
        {
            UserId = "matheus@gmail.com",
            Id = id
        };
        
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result.Data) 
            : TypedResults.BadRequest(result.Data);
    }
}