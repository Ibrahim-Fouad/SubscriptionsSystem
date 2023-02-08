namespace SubscriptionsSystem.Application.Abstractions;

public interface IRepository<T> where T : class
{
    public IQueryable<T> Query { get; }
    void Add(T entity);
}