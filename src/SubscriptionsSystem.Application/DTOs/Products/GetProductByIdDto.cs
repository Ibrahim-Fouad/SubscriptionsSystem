using System.ComponentModel.DataAnnotations;
using MediatR;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.DTOs.Products;

public record GetProductByIdDto([Required, Range(1, int.MaxValue)] int Id) : IRequest<OperationResult<ProductDto>>;