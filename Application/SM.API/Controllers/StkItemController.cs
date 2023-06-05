using MediatR;
using Microsoft.AspNetCore.Mvc;
using SM.Core.Features.Clients.Queries.CommonVms;
using SM.Core.Features.Clients.Queries.GetClientDetails;
using SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions;
using SM.Core.Features.StkItem.Queries.GetStockItemDetals;
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


        [HttpGet("getStkItemIdCodeDesc/{type}/{skip}/{take}")]
        [ProducesResponseType(typeof(IEnumerable<StkItemIdCodeDescriptionsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StkItemIdCodeDescriptionsVm>>> getStkItemIdCodeDesc(string type, int skip, int take, string? filterText)
        {
            var query = new GetStkItemIdCodeDescriptionsQuery(type, skip, take, filterText);
            var stkItemIdCodeDescriptions = await _mediator.Send(query);
            return Ok(stkItemIdCodeDescriptions);
        }

        [HttpGet("getStockItem/{stockLink}")]
        [ProducesResponseType(typeof(StockItemDetalsVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StockItemDetalsVm>> GetClientDetails(int stockLink)
        {
            var query = new GetStockItemDetalsQuery(stockLink);
            var stockItemDetails = await _mediator.Send(query);
            return Ok(stockItemDetails);
        }
    }
}
