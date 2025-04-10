using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;
using SmartStore.Domain.Interfaces;
using SmartStore.Infrastructure;
using SmartStore.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// DI and DbContext setup
builder.Services.AddDbContext<SmartStoreContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddRepositories();


var app = builder.Build();

// Minimal API Endpoints
app.MapGet("/products", async ([FromServices] IRepository<Product> repo) =>
{
    
    var products = await repo.GetAllAsync();
    return Results.Ok(products);
});

app.MapGet("/products/{id:Guid}", async (Guid id, [FromServices] IRepository<Product> repo) =>
{
    var product = await repo.GetByIdAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/products", async (Product product, [FromServices] IRepository<Product> repo) =>
{
    await repo.AddAsync(product);
    return Results.Created($"/products/{product.Id}", product);
});

app.MapPut("/products/{id:Guid}", async (Guid id, Product updated, [FromServices] IRepository<Product> repo) =>
{
    var existing = await repo.GetByIdAsync(id);
    if (existing is null) return Results.NotFound();

    existing.Name = updated.Name;
    existing.Price = updated.Price;

    return Results.Ok(repo.UpdateAsync(existing));
});

app.MapDelete("/products/{id:Guid}", async (Guid id, [FromServices] IRepository<Product> repo) =>
{
    var existing = await repo.GetByIdAsync(id);
    if (existing is null) return Results.NotFound();

    return Results.Ok(repo.RemoveAsync(existing));
});

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SmartStoreContext>();
    await SmartStoreContextSeed.SeedAsync(context);
}

app.Run();