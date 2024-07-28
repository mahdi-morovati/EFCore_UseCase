using EfCore.Application;
using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.ProductCategoryAgg;
using EfCore.Infrastructure.EfCore;
using EfCore.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

// builder.Services.AddDbContext<EfContext>(
//     x => x.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreProject")));
builder.Services.AddDbContext<EfContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();