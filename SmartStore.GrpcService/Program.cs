using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using SmartStore.Application.Features.Products.Queries;
using SmartStore.GrpcService.Services;
using SmartStore.Infrastructure;
using SmartStore.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmartStoreContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddRepositories();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQueryHandler>());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SmartStoreContext>();
    await SmartStoreContextSeed.SeedAsync(context);
}

app.Run();
