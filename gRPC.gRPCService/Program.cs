using gRPC.DAL;
using gRPC.gRPCService.Services;
using Microsoft.EntityFrameworkCore;
using gRPC.Application;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplication(); // Добавляем MediatR и валидацию
builder.Services.AddPersistence(configuration);

var app = builder.Build();

// Применение миграций и создание базы данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // Применение миграций
    }
    catch (Exception ex)
    {
        throw new Exception($"An error occurred creating the DB: {ex}");
    }
}

app.MapGrpcService<UserServiceGrpc>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
