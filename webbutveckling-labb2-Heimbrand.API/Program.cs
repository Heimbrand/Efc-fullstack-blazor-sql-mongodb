using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_Heimbrand.API.Extensions;
using webbutveckling_labb2_Heimbrand.DB;
using webbutveckling_labb2_Heimbrand.DB.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Labb2WebbOlleDb");
builder.Services.AddDbContext<WebbHandelDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICustomerService<Customer>, CustomerRepository>();
builder.Services.AddScoped<IProductService<Product>, ProductRepository>();
builder.Services.AddScoped<ICategoryService<Category>, CategoryRepository>();
builder.Services.AddScoped<IOrderService<Order>, OrderRepository>();
builder.Services.AddScoped<IOrderProductService<OrderProduct>, OrderProductRepository>();

var app = builder.Build();
app.MapCustomerEndpoints();
app.MapProductEndpoint();
app.MapCategoryEndpoints();
app.MapOrderEndpoints();
app.MapOrderProductEndpoints();


app.Run();
