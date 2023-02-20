using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Domain.Entities;
using SubscriptionsSystem.Infrastructure.Data;

namespace SubscriptionsSystem.Infrastructure.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    private readonly AppDbContext _dbContext;

    public UsersRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default) =>
        GetUserAsync(u => u.Id == id, cancellationToken);

    public Task<User?> GetUserAsync(Expression<Func<User, bool>> expression,
        CancellationToken cancellationToken = default) =>
        _dbContext.Set<User>().FirstOrDefaultAsync(expression, cancellationToken);
}