using SmartStore.Domain.Entities;

namespace SmartStore.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetTopSellingAsync(int count);
        Task<Product?> GetByNameAsync(string name);
    }
}
