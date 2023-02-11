using System.ComponentModel.DataAnnotations;
using MediatR;
using SubscriptionsSystem.Application.DTOs.Users;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.DTOs.Auth;

public record RegisterDto([Required, StringLength(50)] string Username, [Required, StringLength(50)] string Password) : IRequest<OperationResult<UserDto>>;