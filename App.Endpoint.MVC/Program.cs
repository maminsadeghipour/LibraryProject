using App.Domain.AppService.Admin;
using App.Domain.AppService.Book;
using App.Domain.AppService.User;
using App.Domain.Core.Admin.Contract;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.User.Contract;
using App.Domain.Service.Admin;
using App.Domain.Service.Book;
using App.Domain.Service.User;
using App.Infrastructure.Database;
using App.Infrastructure.Repository.Ef.Admin;
using App.Infrastructure.Repository.Ef.Book;
using App.Infrastructure.Repository.Ef.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("AppConectionString"));
});

// Repositories
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

//builder.Services.AddScoped<IUserRepository, App.Infrastructure.Repository.Dapper.UserRepository>();
//builder.Services.AddScoped<IBookRepository, App.Infrastructure.Repository.Dapper.BookRepository>();

// Services
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
// AppService
builder.Services.AddScoped<IAdminAppService, AdminAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IBookAppService, BookAppService>();


var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

