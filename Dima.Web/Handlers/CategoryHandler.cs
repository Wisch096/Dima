using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class CategoryHandler : ICategoryHandler
{
    public Task<BaseResponse<Category>> CreateAsync(CreateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        throw new NotImplementedException();
    }
}