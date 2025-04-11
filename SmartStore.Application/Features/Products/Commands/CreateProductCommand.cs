using MediatR;

namespace SmartStore.Application.Features.Products.Commands
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;
}
