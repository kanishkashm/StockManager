using MediatR;
using SM.Core.Features.Clients.Queries.CommonVms;

namespace SM.Core.Features.Clients.Queries.GetClientsList
{
    public class GetClientsListQuery : IRequest<List<ClientVm>>
    {
    }
}
