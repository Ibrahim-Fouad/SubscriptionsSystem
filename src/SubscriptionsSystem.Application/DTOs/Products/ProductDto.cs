using SubscriptionsSystem.Application.DTOs.Features;

namespace SubscriptionsSystem.Application.DTOs.Products;

public record ProductDto(int Id, string Name, decimal MonthlyPrice, decimal YearlyPrice,
    IReadOnlyCollection<FeatureDto> Features);