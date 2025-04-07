using MediatR;
using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Products;
using Negotiations.Application.Products.Commands.CreateProduct;
using Negotiations.Application.Products.Dtos;
using Negotiations.Application.Products.Queries.GetAllProductsQuery;
using Negotiations.Application.Products.Queries.GetProductById;

namespace Negotiations.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById([FromRoute]int productId)
    {
        var product = await mediator.Send(new GetProductByIdQuery(productId));
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductCommand command)
    {
         var productId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetProductById), new { productId }, null);
    }
}
