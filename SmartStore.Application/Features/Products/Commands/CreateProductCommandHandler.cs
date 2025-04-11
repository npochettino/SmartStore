using MediatR;
using SmartStore.Domain.Entities;
using SmartStore.Domain.Interfaces;

namespace SmartStore.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repo;

        public CreateProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price);

            await _repo.AddAsync(product);
            return product.Id;
        }
    }
}
