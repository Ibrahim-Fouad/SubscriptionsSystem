using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
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
        return HandleResult(await _sender.Send(createProductDto, cancellationToken));
    }

    /// <summary>
    /// Update product.
    /// </summary>
    /// <param name="updateProductDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto,
        CancellationToken cancellationToken)
    {
        return HandleResult(await _sender.Send(updateProductDto, cancellationToken));
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
        return HandleResult(await _sender.Send(request, cancellationToken));
    }
}