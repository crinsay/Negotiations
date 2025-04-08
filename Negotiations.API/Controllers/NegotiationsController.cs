using MediatR;
using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Negotiations.Commands;
using Negotiations.Application.Negotiations.Dtos;
using Negotiations.Application.Negotiations.Queries.GetAllNegotiationsForProduct;
using Negotiations.Application.Negotiations.Queries.GetNegotiationByIdForProduct;

namespace Negotiations.API.Controllers;

[ApiController]
[Route("api/products/{productId}/negotiation")]
public class NegotiationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int productId, CreateNegotiationCommand command)
    {
        command.ProductId = productId;

        await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NegotiationDto>>> GetAllNegotiationsForProduct([FromRoute] int productId)
    {
        var negotiations = await mediator.Send(new GetAllNegotiationsForProductQuery(productId));
        return Ok(negotiations);
    }

    [HttpGet("{negotiationId}")]
    public async Task<IActionResult> GetNegotiationByIdForProduct([FromRoute] int productId, [FromRoute]int negotiationId)
    {
        var negotiation = await mediator.Send(new GetNegotiationByIdForProductQuery(productId, negotiationId));
        return Ok(negotiation);
    }
}
