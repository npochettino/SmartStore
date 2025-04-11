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
                new Product(Guid.NewGuid(), "Laptop", 999.99m, true),
                new Product(Guid.NewGuid(), "Smartphone", 699.99m, true),
                new Product(Guid.NewGuid(), "Headphones", 199.99m, true)
            ]);

                await context.SaveChangesAsync();
            }
        }
    }

}
