using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Domain.Entities;
using SubscriptionsSystem.Infrastructure.Data;

namespace SubscriptionsSystem.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : AggregateRoot
{
    private readonly AppDbContext _dbContext;

    protected Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) 
        => _dbContext.Set<T>().AnyAsync(expression, cancellationToken);

    public void Add(T entity) 
        => _dbContext.Add(entity);

    public void Remove(T entity) 
        => _dbContext.Remove(entity);
}