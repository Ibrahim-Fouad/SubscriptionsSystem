using SubscriptionsSystem.Domain.Entities;
using System.Linq.Expressions;

namespace SubscriptionsSystem.Application.Abstractions;

public interface IUsersRepository
{
    Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<User?> GetUserAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);
    void Add(User entity);
}