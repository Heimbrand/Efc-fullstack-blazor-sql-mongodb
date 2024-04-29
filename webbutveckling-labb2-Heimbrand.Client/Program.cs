using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Interfaces;
using Services_labb2_Heimbrand.Client.Services;
using webbutveckling_labb2_Heimbrand.Client.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("Labb2WebbOlleDb",
    client =>
        client.BaseAddress = new Uri("http://localhost:5118")
);

builder.Services.AddMudServices();
builder.Services.AddScoped<IProductService<ProductDto>, ProductService>();
builder.Services.AddScoped<ICategoryService<CategoryDto>, CategoryService>();
builder.Services.AddScoped<IOrderService<OrderDto>, OrderService>();
builder.Services.AddScoped<IOrderProductService<OrderProductDto>, OrderProductService>();
builder.Services.AddScoped<ICustomerService<CustomerDto>, CustomerService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
