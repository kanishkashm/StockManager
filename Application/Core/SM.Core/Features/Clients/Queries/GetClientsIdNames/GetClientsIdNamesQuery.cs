using MediatR;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;

namespace SM.Core.Features.Clients.Queries.GetClientsList
{
    public class GetClientsIdNamesQuery : IRequest<IEnumerable<ClientsIdNamesVm>>
    {
    }
}
