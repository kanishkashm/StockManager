using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.Core.Features.Clients.Queries.CommonVms;
using SM.Core.Features.Clients.Queries.GetClientDetails;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;
using SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging;
using SM.Core.Features.Clients.Queries.GetClientsList;
using System.Net;

namespace SM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getClientsIdNames")]
        [ProducesResponseType(typeof(IEnumerable<ClientsIdNamesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientsIdNamesVm>>> GetClientsIdNames()
        {
            var query = new GetClientsIdNamesQuery();
            var clientsIdNames = await _mediator.Send(query);
            return Ok(clientsIdNames);
        }

        [HttpGet("getClientsIdNamesPaging/{skip}/{take}")]
        [ProducesResponseType(typeof(ClientsIdNamesPagingVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientsIdNamesPagingVm>> GetClientsIdNamesPaging(int skip, int take, string? filterText)
        {
            var query = new GetClientsIdNamesPagingQuery(skip, take, filterText);
            var clientsIdNames = await _mediator.Send(query);
            return Ok(clientsIdNames);
        }

        [HttpGet("getClientDetails/{clientId}")]
        [ProducesResponseType(typeof(ClientVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientVm>> GetClientDetails(int clientId)
        {
            var query = new GetClientDetailsQuery(clientId);
            var clientsIdNames = await _mediator.Send(query);
            return Ok(clientsIdNames);
        }
    }
}
