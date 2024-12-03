using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<BaseResponse<Category>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
            };
        
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new BaseResponse<Category>(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Falha ao criar uma categoria");
        }
    }

    public Task<BaseResponse<Category>> UpdateAsync(UpdateCategoryRequests request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category>> DeleteAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAllAsync(GetAllCategoriesRequest request)
    {
        throw new NotImplementedException();
    }
}