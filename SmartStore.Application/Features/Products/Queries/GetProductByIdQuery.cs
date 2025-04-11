using MediatR;
using SmartStore.Domain.Entities;

namespace SmartStore.Application.Features.Products.Queries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Product?>;
}
