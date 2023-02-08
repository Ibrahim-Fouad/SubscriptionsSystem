using SubscriptionsSystem.Application.DTOs.Users;

namespace SubscriptionsSystem.Application.Abstractions;

public interface IUsersService
{
    Task<UserDto> GetUserByIdAsync(int id);
}