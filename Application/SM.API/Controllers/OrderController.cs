using MediatR;
using Microsoft.AspNetCore.Mvc;
using SM.Core.Features.Order.Command;
using System.Net;

namespace SM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "PlaceOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PlaceOrder([FromBody] OrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
