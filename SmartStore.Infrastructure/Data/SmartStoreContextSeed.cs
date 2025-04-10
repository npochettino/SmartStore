using SmartStore.Domain.Entities;

namespace SmartStore.Infrastructure.Data
{
    public static class SmartStoreContextSeed
    {
        public static async Task SeedAsync(SmartStoreContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                [
                new Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 999.99m, SalesCount = 10 },
                new Product { Id = Guid.NewGuid(), Name = "Smartphone", Price = 699.99m, SalesCount = 20 },
                new Product { Id = Guid.NewGuid(), Name = "Headphones", Price = 199.99m, SalesCount = 5 }
            ]);

                await context.SaveChangesAsync();
            }
        }
    }

}
