using System.Security.Authentication.ExtendedProtection;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Scoped lifetime of http request
// Transient Method level
// Singleton, application startup, stop on stop
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserIdentityRepository, UserIdentityRepository>();
var app = builder.Build();

app.MapControllers();

// Seed data
try
{
    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
