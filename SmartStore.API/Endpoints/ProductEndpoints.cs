using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Application.Features.Products.Commands;
using SmartStore.Application.Features.Products.Queries;
using SmartStore.Domain.Entities;
using SmartStore.Domain.Interfaces;

namespace SmartStore.API.Endpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/products", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllProductsQuery());
                return Results.Ok(result);
            });

            endpoints.MapGet("/products/{id:Guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetProductByIdQuery(id));
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            endpoints.MapPost("/products", async (CreateProductCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Created($"/products/{result}", command);
            });

            endpoints.MapPut("/products/{id:Guid}", async (Guid id, UpdateProductCommand command, IMediator mediator) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest();
                }
                var result = await mediator.Send(command);
                return Results.Ok(result);
            });

            endpoints.MapDelete("/products/{id:Guid}", async (Guid id, [FromServices] IRepository<Product> repo) =>
            {
                var existing = await repo.GetByIdAsync(id);
                if (existing is null) return Results.NotFound();

                return Results.Ok(repo.RemoveAsync(existing));
            });

            return endpoints;
        }
    }
}
