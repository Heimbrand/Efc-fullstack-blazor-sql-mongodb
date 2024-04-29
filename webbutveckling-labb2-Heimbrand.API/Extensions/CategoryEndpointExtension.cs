using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling_labb2_Heimbrand.API.Extensions;

public static class CategoryEndpointExtension
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/category");

        group.MapGet("/", async (ICategoryService<Category> repository) =>
        {
            var categories = await repository.GetAllCategories();
            if (categories is null)
            {
                return Results.BadRequest("Database does not contain any categories");
            }
            return Results.Ok(categories);
        });
        
        group.MapGet("/name/{name}", async (ICategoryService<Category> repository, string name) =>
        {
            var category = await repository.GetCategoryByName(name);
            if (category is null)
            {
                return Results.BadRequest("The provided name does not exists in the database");
            }
            return Results.Ok(category);
        });

        group.MapPost("/", async (ICategoryService<Category> repository, Category category) =>
        {
            await repository.AddCategory(category);
            return Results.Created($"/api/category/{category.Id}", category);
        });

        group.MapPut("/{id}", async (ICategoryService<Category> repository, int id, Category category) =>
        {
            if (id != category.Id)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            await repository.UpdateCategory(category);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (ICategoryService<Category> repository, int id) =>
        {
            await repository.DeleteCategory(id);
            return Results.NoContent();
        });

        return app;
    }
}