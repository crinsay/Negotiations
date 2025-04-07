using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Negotiations.Application.Negotiations;

namespace Negotiations.API.Controllers;

[ApiController]
[Route("api/products/{productId}/negotiation")]
public class NegotiationsController() : ControllerBase
{

}
