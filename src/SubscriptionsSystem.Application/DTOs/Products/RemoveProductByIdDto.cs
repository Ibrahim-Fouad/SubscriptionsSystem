using MediatR;
using System.ComponentModel.DataAnnotations;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.DTOs.Products;

public record RemoveProductByIdDto([Required, Range(1, int.MaxValue)] int Id) : IRequest<OperationResult<Unit>>;