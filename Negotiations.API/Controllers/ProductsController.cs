using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Products;

namespace Negotiations.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await productsService.GetAllProductsAsync();
        return Ok(products);
    }
}
