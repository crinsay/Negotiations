﻿using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById([FromRoute]int productId)
    {
        var product = await productsService.GetProductByIdAsync(productId);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
}
