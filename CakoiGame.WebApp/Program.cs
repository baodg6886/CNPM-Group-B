using CakoiGame.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using CakoiGame.Repositories.Interfaces;
using CakoiGame.Services.Interfaces;
using CakoiGame.Repositories;
using CakoiGame.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<CakoiContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Add services to the container.
builder.Services.AddScoped<IUserRep, UserRep>();
builder.Services.AddScoped<IUserSvc, UserSvc>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
