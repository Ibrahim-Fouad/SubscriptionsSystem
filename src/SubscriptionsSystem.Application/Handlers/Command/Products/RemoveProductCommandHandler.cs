using MediatR;
using Microsoft.Extensions.Logging;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Enums;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.Application.Handlers.Command.Products;

internal class RemoveProductCommandHandler : IRequestHandler<RemoveProductByIdDto, OperationResult<Unit>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RemoveProductCommandHandler> _logger;

    public RemoveProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork,
        ILogger<RemoveProductCommandHandler> logger)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<OperationResult<Unit>> Handle(RemoveProductByIdDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting product '{Id}'", request.Id);
        var product = await _productsRepository.GetProductByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            _logger.LogInformation("Product '{Id}' is not found.", request.Id);
            return DomainErrors.ProductIsNotFound;
        }

        _productsRepository.Remove(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}