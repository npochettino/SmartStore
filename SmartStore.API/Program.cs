using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartStore.API.Endpoints;
using SmartStore.Application.Features.Products.Commands;
using SmartStore.Application.Features.Products.Queries;
using SmartStore.Infrastructure;
using SmartStore.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmartStoreContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddRepositories();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQueryHandler>());
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<GetProductByIdQueryHandler>());
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateProductCommandHandler>());
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<UpdateProductCommandHandler>());

var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

var app = builder.Build();

app.MapProductEndpoints();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SmartStoreContext>();
    await SmartStoreContextSeed.SeedAsync(context);
}

app.Run();