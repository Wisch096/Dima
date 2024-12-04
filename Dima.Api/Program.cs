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
    "/v1/categories",
    (CreateCategoryRequest request, ICategoryHandler handler) => handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<BaseResponse<Category>>();

app.MapPut(
        "/v1/categories/{id}",
        (long id, UpdateCategoryRequest request, 
            ICategoryHandler handler) 
            =>
        {
            request.Id = id;
            handler.UpdateAsync(request);
        })
    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<BaseResponse<Category>>();

app.MapDelete(
        "/v1/categories/{id}",
        (long id, DeleteCategoryRequest request, 
            ICategoryHandler handler) 
            =>
        {
            request.Id = id;
             handler.DeleteAsync(request);
        })
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma categoria")
    .Produces<BaseResponse<Category>>();

app.Run();






