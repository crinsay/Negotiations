using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Negotiations;

namespace Negotiations.API.Controllers;

[ApiController]
[Route("api/products/{productId}/negotiation")]
public class NegotiationsController(INegotiationsService negotiationsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllNegotiaions()
    {
        var negotiations = await negotiationsService.GetAllNegotiationsAsync();
        return Ok(negotiations);
    }
}
