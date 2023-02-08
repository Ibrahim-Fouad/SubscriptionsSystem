using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Users;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Services;

public class UsersService : IUsersService 
{
    private readonly IRepository<User> _userRepository;
    public Task<UserDto> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}