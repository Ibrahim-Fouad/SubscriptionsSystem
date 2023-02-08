using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Infrastructure.Data;

namespace SubscriptionsSystem.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<T> Query => _dbContext.Set<T>();

    public void Add(T entity)
        => _dbContext.Add(entity);
}