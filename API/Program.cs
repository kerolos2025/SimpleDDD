using Application.Commands;
using Application.Queries;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── Services ──
builder.Services.AddControllers();

// Swagger v7 configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Simple DDD API",
        Version = "v1",
        Description = "A simple Domain-Driven Design example with .NET 9"
    });
});

// ── DDD Layers ──
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure") // Migrations live in Infrastructure
    );

    // Optional: log SQL to console
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateStudentCommand).Assembly));

var app = builder.Build();

// ── Middleware Pipeline ──
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple DDD API v1");
        //options.RoutePrefix = string.Empty; // Swagger at root: https://localhost:7001/
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();