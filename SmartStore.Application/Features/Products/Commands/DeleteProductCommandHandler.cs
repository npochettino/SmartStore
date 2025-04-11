using MediatR;
using SmartStore.Domain.Interfaces;

namespace SmartStore.Application.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repo;

        public DeleteProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            if (product is null) return false;

            await _repo.RemoveAsync(product);
            return true;
        }
    }
}
