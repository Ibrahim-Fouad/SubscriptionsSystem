using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Entities;
using SubscriptionsSystem.Domain.Enums;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.Handlers.Command.Products;

internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductDto, OperationResult<ProductDto>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateProductCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork,
        ILogger<UpdateProductCommandHandler> logger, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<OperationResult<ProductDto>> Handle(UpdateProductDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting product with id: {0}", request.Id);
        var product = await _productsRepository.GetProductByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            _logger.LogInformation("Product with id '{Id}' is not found.", request.Id);
            return DomainErrors.ProductIsNotFound;
        }

        product.ChangeName(request.Name);
        product.ChangePrice(request.MonthlyPrice, request.YearlyPrice);
        var features = request.Features.Select(x => (x.Name, x.Description)).ToArray();
        product.UpdateFeatures(features);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }
}