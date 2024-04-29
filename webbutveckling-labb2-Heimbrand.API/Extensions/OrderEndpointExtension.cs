using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling_labb2_Heimbrand.API.Extensions;

public static class OrderEndpointExtension
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/order");

        group.MapGet("/", async (IOrderService<Order> repository) =>
        {
            var orders = await repository.GetAllOrders();

            if (orders is null)
            {
                return Results.BadRequest("Database does not contain any orders");
            }
            return Results.Ok(orders);
        });

        group.MapGet("/{id}", async (IOrderService<Order> repository, int id) =>
        {
            var order = await repository.GetOrderById(id);
            if (order is null)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            return Results.Ok(order);
        });

        group.MapGet("/customer/{customerId}", async (IOrderService<Order> repository, int customerId) =>
        {
            var order = await repository.GetOrdersByCustomerId(customerId);
            if (order is null)
            {
                return Results.BadRequest("The provided customer id does not exists in the database");
            }
            return Results.Ok(order);
        });

        group.MapPost("/", async (IOrderService<Order> repository, Order order) =>
        {
            return await repository.CreateOrder(order);
        });

        group.MapDelete("/{id}", async (IOrderService<Order> repository, int id) =>
        {
            await repository.DeleteOrder(id);
            return Results.NoContent();
        });
        return app;
    }
}