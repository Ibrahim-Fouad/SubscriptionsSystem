using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SubscriptionsSystem.Application.DTOs.Auth;

public record LoginDto([Required] string Username, [Required] string Password) : IRequest<UserWithTokenDto>;