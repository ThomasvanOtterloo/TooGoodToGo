using Core.Domain.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Portal.Models;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
var connectionStringAuth = builder.Configuration.GetConnectionString("Security");
builder.Services.AddDbContext<PackageDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionStringAuth));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthDbContext>();


builder.Services.AddAuthorization(options =>
    options.AddPolicy("Employee", policy => policy.RequireClaim("Employee")));
builder.Services.AddAuthorization(options =>
    options.AddPolicy("Student", policy => policy.RequireClaim("Student")));



builder.Services.AddScoped<ICanteenRepository, CanteenEFRepository>();
builder.Services.AddScoped<IPackageRepository, PackageEFRepository>();
builder.Services.AddScoped<IStudentRepository, StudentEFRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeEFRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IProductRepository, ProductEFRepository>();


// Add services to the container. 
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.as
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "packages",
    pattern: "{controller=Packages}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "authentication",
    pattern: "{controller=Authentication}/{action=Login}/{id?}");





app.Run();


