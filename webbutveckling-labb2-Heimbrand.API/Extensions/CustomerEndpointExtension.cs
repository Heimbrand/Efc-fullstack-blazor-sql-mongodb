using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling_labb2_Heimbrand.API.Extensions;

public static class CustomerEndpointExtension
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/customer");

        group.MapGet("/", async (ICustomerService<Customer> repository) =>
        {
            var users = await repository.GetAllCustomers();

            if (users is null)
            {
                return Results.BadRequest("Database does not contain any users");
            }
            return Results.Ok(users);
        });

        group.MapGet("/OrderProduct/{id}", async (ICustomerService<Customer> repository, int id) =>
        {

            var user = await repository.GetOrderProductsByCostumerId(id);

            if (user is null)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            return Results.Ok(user);
        });

        group.MapGet("/{id}", async (ICustomerService<Customer> repository, int id) =>
        {
            var user = await repository.GetCustomerById(id);
            if (user is null)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            return Results.Ok(user);
        });

        group.MapGet("/email/{email}", async (ICustomerService<Customer> repository, string email) =>
        {
            var user = await repository.GetCustomerByEmail(email);

            if (user is null)
            {
                return Results.BadRequest("No Customer found with the email you have provided");
            }
            return Results.Ok(user);
        });

        group.MapGet("/phone/{phone}", async (ICustomerService<Customer> repository, string phone) =>
        {
            var user =  await repository.GetCustomerByPhone(phone);
            if (user is null)
            {
                return Results.BadRequest("The provided phone does not exists in the database");
            }
            return Results.Ok(user);
        });

        group.MapPost("/", async (ICustomerService<Customer> repository, Customer customer) =>
        {
            await repository.AddCustomer(customer);
            return Results.Created($"/api/customer/{customer.Id}", customer);
        });

        group.MapPut("/{id}", async (ICustomerService<Customer> repository, int id, Customer customer) =>
        {
            if (id != customer.Id)
            {
                return Results.BadRequest("The provided id does not exists in the database");
            }
            await repository.UpdateCustomer(customer);
            return Results.NoContent();
        });

        group.MapPut("/{id}/name/{name}", async (ICustomerService<Customer> repository, int id, string name) =>
        {
            await repository.UpdateCustomerFirstName(id, name);
            return Results.NoContent();
        });

        group.MapPut("/{id}/lastname/{name}", async (ICustomerService<Customer> repository, int id, string name) =>
        {
            await repository.UpdateCustomerLastName(id, name);
            return Results.NoContent();
        });

        group.MapPut("/{id}/email/{email}", async (ICustomerService<Customer> repository, int id, string email) =>
        {
            await repository.UpdateCustomerEmail(id, email);
            return Results.NoContent();
        });

        group.MapPut("/{id}/phone/{phone}", async (ICustomerService<Customer> repository, int id, string phone) =>
        {
            await repository.UpdateCustomerPhone(id, phone);
            return Results.NoContent();
        });

        group.MapPut("/{id}/adress/{adress}", async (ICustomerService<Customer> repository, int id, string adress) =>
        {
            await repository.UpdateCustomerAddress(id, adress);
            return Results.NoContent();
        });

        group.MapPut("/{id}/city/{city}", async (ICustomerService<Customer> repository, int id, string city) =>
        {
            await repository.UpdateCustomerCity(id, city);
            return Results.NoContent();
        });

        group.MapPut("/{id}/zip/{zip}", async (ICustomerService<Customer> repository, int id, string zip) =>
        {
            await repository.UpdateCustomerZip(id, zip);
            return Results.NoContent();
        });

        group.MapPut("/{id}/country/{country}", async (ICustomerService<Customer> repository, int id, string country) =>
        {
            await repository.UpdateCustomerCountry(id, country);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (ICustomerService<Customer> repository, int id) =>
        {
            await repository.DeleteCustomer(id);
            return Results.NoContent();
        });

        return app;
    }
}