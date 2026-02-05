using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Services;
using Shop.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<ShopContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
