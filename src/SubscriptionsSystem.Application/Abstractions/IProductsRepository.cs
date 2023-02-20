using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Abstractions;

public interface IProductsRepository : IRepository<Product>
{
    Task<Product?> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<TResult?> GetProductByIdAsync<TResult>(int productId, CancellationToken cancellationToken = default);
}