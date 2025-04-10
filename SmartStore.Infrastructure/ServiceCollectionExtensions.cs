using Microsoft.Extensions.DependencyInjection;
using SmartStore.Domain.Entities;
using SmartStore.Domain.Interfaces;
using SmartStore.Infrastructure.Repositories;

namespace SmartStore.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRepository<Product>>(sp => sp.GetRequiredService<IProductRepository>());

            return services;
        }
    }
}
