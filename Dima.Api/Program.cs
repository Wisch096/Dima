using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(cnnStr);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});
builder
    .Services
    .AddTransient<ICategoryHandler, CategoryHandler>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dima API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.MapPost(
    "/v1/categories", async (CreateCategoryRequest request, ICategoryHandler handler) 
        => await handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<BaseResponse<Category>>();

app.MapPut(
        "/v1/categories/{id}",
        async (long id, UpdateCategoryRequest request, 
            ICategoryHandler handler) 
            =>
        {
            request.Id = id;
            return await handler.UpdateAsync(request);
        })
    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<BaseResponse<Category>>();

app.MapDelete(
        "/v1/categories/{id}",
        async (long id, ICategoryHandler handler) 
            =>
        {
            var request = new DeleteCategoryRequest { Id = id };
            return await handler.DeleteAsync(request);
        })
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma categoria")
    .Produces<BaseResponse<Category>>();

app.MapGet(
        "/v1/categories/{id}",
        async (long id, ICategoryHandler handler) 
            =>
        {
            var request = new GetCategoryByIdRequest() { Id = id, UserId = "matheus@email.com"};
            return await handler.GetByIdAsync(request);
        })
    .WithName("Categories: GetById")
    .WithSummary("Retorna uma categoria")
    .Produces<BaseResponse<Category>>();

app.Run();






