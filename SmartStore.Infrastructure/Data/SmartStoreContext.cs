using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;

namespace SmartStore.Infrastructure.Data
{
    public class SmartStoreContext : DbContext
    {
        public SmartStoreContext(DbContextOptions<SmartStoreContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
