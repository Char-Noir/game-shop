using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Service.Interface;
using GameShop.Models.Service.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameShopContextConnection") ?? throw new InvalidOperationException("Connection string 'GameShopContextConnection' not found.");

builder.Services.AddDbContext<GameShopContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GameShopContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GameShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameShopContext") ?? throw new InvalidOperationException("Connection string 'GameShopContext' not found.")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShopCartService, ShopCartService>();
builder.Services.AddScoped<IEmailSender, GmailSender>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.UseStatusCodePagesWithReExecute("/NotFound");
app.Run();
