using MediatR;
using Microsoft.Extensions.Logging;
using SmartStore.Application.Features.Products.Queries;
using SmartStore.Domain.Entities;
using SmartStore.Domain.Interfaces;

namespace SmartStore.Application.Features.Products.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<GetAllProductsHandler> _logger;

        public GetAllProductsHandler(IProductRepository repository, ILogger<GetAllProductsHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all products...");
            return _repository.GetAllAsync();
        }
    }
}
