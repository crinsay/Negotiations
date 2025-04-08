using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Products.Commands.CreateProduct;
using Negotiations.Application.Products.Commands.DeleteProduct;
using Negotiations.Application.Products.Queries.GetAllProductsQuery;
using Negotiations.Application.Products.Queries.GetProductById;

namespace Negotiations.API.Controllers;

[ApiController]
[Route("api/products")]
[Authorize]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpGet("{productId}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById([FromRoute]int productId)
    {
        var product = await mediator.Send(new GetProductByIdQuery(productId));

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductCommand command)
    {
         var productId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetProductById), new { productId }, null);
    }

    [HttpDelete("{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] int productId)
    {
        await mediator.Send(new DeleteProductCommand(productId));
        return NoContent();
    }
}
