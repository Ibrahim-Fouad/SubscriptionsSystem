using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Features;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Entities;
using SubscriptionsSystem.Domain.Enums;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.Handlers.Command.Products;

internal class CreateProductCommandHandler : IRequestHandler<CreateProductDto, OperationResult<ProductDto>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork,
        ILogger<CreateProductCommandHandler> logger, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<OperationResult<ProductDto>> Handle(CreateProductDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking for product name existence...");
        if (await _productsRepository.AnyAsync(p => p.Name == request.Name, cancellationToken))
        {
            _logger.LogInformation("Product name: '{0}' is already exists.", request.Name);
            return DomainErrors.ProductNameIsAlreadyExists;
        }

        _logger.LogInformation("Creating new product..");
        var product = Product.Create(request.Name, request.MonthlyPrice, request.YearlyPrice);
        _logger.LogInformation("Product '{0}' created, adding features..", product.Name);

        foreach (var createFeatureDto in request.Features)
            product.AddFeature(createFeatureDto.Name, createFeatureDto.Description);

        _productsRepository.Add(product);
        _logger.LogInformation("Saving to database...");
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Saving to database is done!");
        return _mapper.Map<ProductDto>(product);
    }
}