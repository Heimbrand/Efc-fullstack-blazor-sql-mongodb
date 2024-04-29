using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_Heimbrand.Client.AuthApi.Components;
using webbutveckling_labb2_Heimbrand.Client.AuthApi.Components.Account;
using webbutveckling_labb2_Heimbrand.Client.AuthApi.Data;
using MudBlazor.Services;
using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Interfaces;
using webbutveckling;
using webbutveckling_labb2_Heimbrand.Client.AuthApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddCascadingAuthenticationState();
builder.Services.AddMudServices();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IProductService<ProductDto>, ProductService>();
builder.Services.AddScoped<ICategoryService<CategoryDto>, CategoryService>();
builder.Services.AddScoped<IOrderService<OrderDto>, OrderService>();
builder.Services.AddScoped<IOrderProductService<OrderProductDto>, OrderProductService>();
builder.Services.AddScoped<ICustomerService<CustomerDto>, CustomerService>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();


builder.Services.AddHttpClient("Labb2WebbOlleDb",
    client =>
        client.BaseAddress = new Uri("http://localhost:5118")
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
   
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapAdditionalIdentityEndpoints();

app.Run();
