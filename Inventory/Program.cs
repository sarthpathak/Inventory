using Inventory.Controllers;
using Inventory.Domain;
using Inventory.Reposits;
using Microsoft.EntityFrameworkCore;
using Inventory.NewFolder;
using Inventory.Context;
using Inventory.Interfaces;
using Inventory.Implementations;
using System;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<ProductCategory>, Repository<ProductCategory>>();
builder.Services.AddScoped<IRepository<OrderProduct>, Repository<OrderProduct>>();


// Add services to the container.
builder.Services.AddDbContext<Managementdbcontext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
void ApplyMigration()
{
    using (var scope = app?.Services.CreateScope())
    {
        var _db = scope?.ServiceProvider.GetRequiredService<Managementdbcontext>();

        if (_db?.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}

ApplyMigration();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware();
app.MapControllers();

app.Run();
