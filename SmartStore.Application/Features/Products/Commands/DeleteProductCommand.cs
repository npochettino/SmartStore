using MediatR;

namespace SmartStore.Application.Features.Products.Commands
{
    public record DeleteProductCommand(Guid Id) : IRequest<bool>;
}
