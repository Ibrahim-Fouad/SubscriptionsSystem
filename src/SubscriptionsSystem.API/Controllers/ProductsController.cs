using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create new product with features.
    /// </summary>
    /// <param name="createProductDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto,
        CancellationToken cancellationToken)
    {
        return HandleResult(await _mediator.Send(createProductDto, cancellationToken));
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <param name="productId">Id of product.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{productId:int}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById(int productId,
        CancellationToken cancellationToken)
    {
        var request = new GetProductByIdDto(productId);
        return HandleResult(await _mediator.Send(request, cancellationToken));
    }
}