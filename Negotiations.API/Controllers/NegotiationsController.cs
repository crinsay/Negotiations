using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Negotiations;
using Negotiations.Application.Negotiations.Commands;

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
}
