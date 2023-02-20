using System.ComponentModel.DataAnnotations;
using MediatR;
using SubscriptionsSystem.Application.Constants;
using SubscriptionsSystem.Application.DTOs.Features;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.DTOs.Products;

public record CreateProductDto(
    [Required, StringLength(100)] string Name,
    [Required, Range(PriceConstants.MinimumPriceValue, PriceConstants.MaximumPriceValue)]
    decimal MonthlyPrice,
    [Required, Range(PriceConstants.MinimumPriceValue, PriceConstants.MaximumPriceValue)]
    decimal YearlyPrice,
    [Required, MinLength(1)] IReadOnlyCollection<CreateFeatureDto> Features
) : IRequest<OperationResult<ProductDto>>;