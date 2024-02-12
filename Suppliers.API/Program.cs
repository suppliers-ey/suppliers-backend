using Microsoft.EntityFrameworkCore;
using Suppliers.Domain;
using Suppliers.Infrastructure;
using Suppliers.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<ISupplierInfrastructure, SupplierInfrastructure>();
builder.Services.AddScoped<ISupplierDomain, SupplierDomain>();

// Database Connection
builder.Services.AddDbContext<SupplierContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Create database if not exists
using (var serviceScope = app.Services.CreateScope())
using (var context = serviceScope.ServiceProvider.GetService<SupplierContext>())
{
    var services = serviceScope.ServiceProvider;
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure CORS
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();