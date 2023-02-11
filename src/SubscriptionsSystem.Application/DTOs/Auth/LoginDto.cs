using System.ComponentModel.DataAnnotations;
using MediatR;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.DTOs.Auth;

public record LoginDto([Required] string Username, [Required] string Password) : IRequest<OperationResult<UserWithTokenDto>>;