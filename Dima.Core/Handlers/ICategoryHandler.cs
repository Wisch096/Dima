﻿using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface ICategoryHandler
{
    Task<BaseResponse<Category>> CreateAsync(CreateCategoryRequest request);
    Task<BaseResponse<Category>> UpdateAsync(UpdateCategoryRequests request);
    Task<BaseResponse<Category>> DeleteAsync(DeleteCategoryRequest request);
    Task<BaseResponse<Category>> GetByIdAsync(GetCategoryByIdRequest request);
    Task<List<Category>> GetAllAsync(GetAllCategoriesRequest request);
}