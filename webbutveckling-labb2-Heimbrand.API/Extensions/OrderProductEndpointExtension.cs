using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling_labb2_Heimbrand.API.Extensions;

public static class OrderProductEndpointExtension
{
    public static IEndpointRouteBuilder MapOrderProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/orderproduct");

        group.MapGet("/", async (IOrderProductService<OrderProduct> repository) =>
        {
            var OrderProducts = await repository.GetAllOrderProducts();
            if (OrderProducts is null)
            {
                return Results.BadRequest("Database does not contain any orderproducts");
            }
            return Results.Ok(OrderProducts);
        });

        group.MapPost("/", async (IOrderProductService<OrderProduct> repository, OrderProduct orderProduct) =>
        {
            await repository.AddOrderProduct(orderProduct);
            return Results.Created($"/api/orderproduct/{orderProduct.OrderId}", orderProduct);
        });

        group.MapPut("/{orderId}/{productId}",
            async (IOrderProductService<OrderProduct> repository, int orderId, int productId, OrderProduct orderProduct) =>
            {
                if (orderId != orderProduct.OrderId || productId != orderProduct.ProductId)
                {
                    return Results.BadRequest("The provided id does not exists in the database");
                }
                await repository.UpdateOrderProduct(orderProduct);
                return Results.NoContent();
            });

        return app;
    }

}