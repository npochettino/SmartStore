using MediatR;

namespace SmartStore.Application.Features.Products.Commands
{
    public record CreateProductCommand(string Name, double Price) : IRequest<Guid>;
}
