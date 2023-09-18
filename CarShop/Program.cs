using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarShop.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using DataAccsess.Entities;
using ShopMVC;
using DataAccsess.Interfaces;
using BuisinessLogic.Interfaces;
using BuisinessLogic.Services;
using DataAccsess;
using CarShop.Services;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("CarShopContext") ?? throw new InvalidOperationException("Connection string 'CarShopContext' not found.");

builder.Services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CarShopContext>();

builder.Services.AddDbContext<CarShopContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();



//add Fluent Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {

    options.IdleTimeout = TimeSpan.FromSeconds(1000);
    options.Cookie.Name = "_ShopMVC.Session";
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});


builder.Services.AddScoped<ICarServices, CarService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped<SessionManager>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrdersServices, OrdersService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFileService, FileService>();

//builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
//builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;
    Seeder.SeedRoles(serviceProvider).Wait();
    Seeder.SeedAdmin(serviceProvider).Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
