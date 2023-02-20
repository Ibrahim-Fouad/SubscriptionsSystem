using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Enums;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.Handlers.Queries.Products;

internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdDto, OperationResult<ProductDto>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductByIdQueryHandler> _logger;

    public GetProductByIdQueryHandler(IProductsRepository productsRepository, IMapper mapper,
        ILogger<GetProductByIdQueryHandler> logger)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<OperationResult<ProductDto>> Handle(GetProductByIdDto request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting product with id: '{0}'", request.Id);
        var product = await _productsRepository.GetProductByIdAsync<ProductDto>(request.Id, cancellationToken);
        if (product is null)
        {
            _logger.LogInformation("Product with id: '{0}' is not found.", request.Id);
            return DomainErrors.ProductIsNotFound;
        }
        _logger.LogInformation("Found product '{0}' with id: '{0}'.", product.Name, request.Id);
        return product;
    }
}