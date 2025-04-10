using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;
using SmartStore.Infrastructure.Data;
using SmartStore.Domain.Interfaces;

namespace SmartStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SmartStoreContext _context;

        public ProductRepository(SmartStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetTopSellingAsync(int count)
        {
            return await _context.Products
                .OrderByDescending(p => p.SalesCount)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        // IRepository<Product> implementation
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product)
        {
            var entity = await _context.Products.FindAsync(product.Id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
