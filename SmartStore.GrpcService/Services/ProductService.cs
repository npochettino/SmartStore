using Grpc.Core;
using SmartStore.Domain.Interfaces;

namespace SmartStore.GrpcService.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            var products = await _repository.GetAllAsync();
            var response = new ProductList();
            response.Products.AddRange(products.Select(x => new ProductResponse
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Price = x.Price
            }));
            return response;
        }

        public override async Task<ProductResponse> GetById(ProductRequest request, ServerCallContext context)
        {
            var product = await _repository.GetByIdAsync(Guid.Parse(request.Id));
            return product == null
                ? throw new RpcException(new Status(StatusCode.NotFound, "Product not found"))
                : new ProductResponse
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
