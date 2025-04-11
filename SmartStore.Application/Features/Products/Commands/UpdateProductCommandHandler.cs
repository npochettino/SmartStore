using MediatR;
using SmartStore.Domain.Interfaces;

namespace SmartStore.Application.Features.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repo;

        public UpdateProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            if (product is null) return false;

            product.SetName(request.Name);
            product.SetPrice(request.Price);

            await _repo.UpdateAsync(product);
            return true;
        }
    }
}
