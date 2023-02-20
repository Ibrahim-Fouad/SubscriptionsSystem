using SubscriptionsSystem.Domain.Entities;
using System.Linq.Expressions;

namespace SubscriptionsSystem.Application.Abstractions;

public interface IUsersRepository : IRepository<User>
{
    Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<User?> GetUserAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);
}