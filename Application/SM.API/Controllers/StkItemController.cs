using MediatR;
using Microsoft.AspNetCore.Mvc;
using SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions;
using System.Net;

namespace SM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StkItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StkItemController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getStkItemIdCodeDesc/{type}")]
        [ProducesResponseType(typeof(IEnumerable<StkItemIdCodeDescriptionsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StkItemIdCodeDescriptionsVm>>> getStkItemIdCodeDesc(string type)
        {
            var query = new GetStkItemIdCodeDescriptionsQuery(type);
            var stkItemIdCodeDescriptions = await _mediator.Send(query);
            return Ok(stkItemIdCodeDescriptions);
        }
    }
}
