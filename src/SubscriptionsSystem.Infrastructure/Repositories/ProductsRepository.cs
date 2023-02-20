using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.Extensions;
using SubscriptionsSystem.Domain.Entities;
using SubscriptionsSystem.Infrastructure.Data;

namespace SubscriptionsSystem.Infrastructure.Repositories;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
    private readonly AppDbContext _dbContext;

    public ProductsRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Product?> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
    {
        return GetProductByIdQuery(productId)
            .Include(p => p.Features)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<TResult?> GetProductByIdAsync<TResult>(int productId, CancellationToken cancellationToken = default)
    {
        return GetProductByIdQuery(productId)
            .MapTo<TResult>()
            .FirstOrDefaultAsync(cancellationToken);
    }

    private IQueryable<Product> GetProductByIdQuery(int productId)
    {
        return _dbContext.Set<Product>()
            .Where(p => p.Id == productId);
    }
}