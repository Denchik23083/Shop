using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Shop.Contracts.Models;
using Shop.Data.CardRepository;
using Shop.Data.CategoryRepository;
using Shop.Data.DbContextScopeFactory;
using Shop.Data.OrderRepository;
using Shop.Data.ProductRepository;
using Shop.Data.AdminRepository;
using Shop.Data.UserRepository;
using Shop.Data.AuthRepository;
using Shop.Db;
using Shop.Db.Entities;
using Shop.Services.CardService;
using Shop.Services.CategoryService;
using Shop.Services.AdminService;
using Shop.Services.OrderService;
using Shop.Services.ProductService;
using Shop.Services.UserService;
using Shop.Services.AuthService;
using Shop.Web.Components;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IDbContextScopeFactory, DbContextScopeFactory>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/";
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = ctx =>
            {
                ctx.Response.Redirect("/login");
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = ctx =>
            {
                ctx.Response.Redirect("/");
                return Task.CompletedTask;
            },
            OnValidatePrincipal = async ctx =>
            {
                var userService = ctx.HttpContext.RequestServices
                    .GetRequiredService<IUserService>();

                var userIdStr = ctx.Principal?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!int.TryParse(userIdStr, out var userId))
                {
                    ctx.RejectPrincipal();
                    await ctx.HttpContext.SignOutAsync();
                    return;
                }

                var user = await userService.GetUserAsync(userId);

                var roleClaim = ctx.Principal?.FindFirstValue(ClaimTypes.Role);

                if (user is null || roleClaim != user.Role.ToString())
                {
                    ctx.RejectPrincipal();
                    await ctx.HttpContext.SignOutAsync();
                    return;
                }
            }
        };
        options.LogoutPath = "/logout";
        options.Cookie.Name = "shop_auth";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(http =>
{
    var nav = http.GetRequiredService<NavigationManager>();

    return new HttpClient
    {
        BaseAddress = new Uri(nav.BaseUri)
    };
});

builder.Services.AddDbContextFactory<ShopContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
    options.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(au =>
{
    au.CreateMap<CardModel, Card>();
    au.CreateMap<ProductModel, Product>();
});

var app = builder.Build();

app.MapPost("/login", async (IAuthService service, LoginModel model, HttpContext http) =>
{
    var user = await service.LoginUserAsync(model);

    if (user is null)
    {
        return Results.Unauthorized();
    }

    var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Name, user.Name),
        new(ClaimTypes.Email, user.Email),
        new(ClaimTypes.Role, user.Role.ToString())
    };

    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

    await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
        new AuthenticationProperties { IsPersistent = true });

    return Results.Ok();
});

app.MapPost("/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    return Results.Ok();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapFallback(() => Results.Redirect("/"));

app.Run();
