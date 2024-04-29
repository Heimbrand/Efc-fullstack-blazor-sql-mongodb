using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling_labb2_Heimbrand.API.Extensions;

public static class ProductEndpointExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/product");

        group.MapGet("/", async (IProductService<Product> repository) =>
        {
            var products = await repository.GetAllProducts();
            if (products is null)
            {
                return Results.BadRequest("Database does not contain any products");
            }
            return Results.Ok(products);
        });

        group.MapGet("/{id}", async (IProductService<Product> repository, int id) =>
        {
            var product = await repository.GetProductById(id);
            if (product is null)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            return Results.Ok(product);
        });

        group.MapGet("/name/{name}", async (IProductService<Product> repository, string name) =>
        {
            var product = await repository.GetProductByName(name);
            if (product is null)
            {
                return Results.BadRequest("The provided name does not exists in the database");
            }
            return Results.Ok(product);
        });

        group.MapPost("/", async (IProductService<Product> repository, Product product) =>
        {
            await repository.AddProduct(product);
            return Results.Created($"/api/product/{product.Id}", product);
        });

        group.MapPut("/{id}", async (IProductService<Product> repository, int id, Product product) =>
        {
            if (id != product.Id)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            await repository.UpdateProduct(product);
            return Results.NoContent();
        });

        group.MapPut("/{id}/price/{price}", async (IProductService<Product> repository, int id, int price) =>
        {
            await repository.UpdateProductPrice(id, price);
            return Results.NoContent();
        });

        group.MapPut("/{id}/description/{description}", async (IProductService<Product> repository, int id, string description) =>
            {
            await repository.UpdateProductDescription(id, description);
            return Results.NoContent();
        });

        group.MapPut("/{id}/name/{name}", async (IProductService<Product> repository, int id, string name) =>
        {
            await repository.UpdateProductName(id, name);
            return Results.NoContent();
        });

        group.MapPut("/{id}/stockBalance/{stockBalance}", async (IProductService<Product> repository, int id, int stockBalance) =>
        {
            await repository.UpdateProductStockBalance(id, stockBalance);
            return Results.NoContent();
        });

        group.MapPut("/{id}/status/{status}", async (IProductService<Product> repository, int id, bool status) =>
        {
            await repository.UpdateProductStatus(id, status);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IProductService<Product> repository, int id) =>
        {
            await repository.DeleteProduct(id);
            return Results.NoContent();
        });

        return app;
    }
}