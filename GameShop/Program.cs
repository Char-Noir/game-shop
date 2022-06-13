using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Service.Interface;
using GameShop.Models.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GameShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameShopContext") ?? throw new InvalidOperationException("Connection string 'GameShopContext' not found.")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IFileService, FileService>();


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

app.UseAuthorization();

app.MapRazorPages();


app.UseStatusCodePagesWithReExecute("/NotFound");
app.Run();
