using MediatR;
using SM.Core.Contracts;

namespace SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging
{
    public class GetClientsIdNamesPagingQueryHandler : IRequestHandler<GetClientsIdNamesPagingQuery, ClientsIdNamesPagingVm>
    {
        private readonly IClientRepository _clientRepo;

        public GetClientsIdNamesPagingQueryHandler(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<ClientsIdNamesPagingVm> Handle(GetClientsIdNamesPagingQuery request, CancellationToken cancellationToken)
        {
            var pagingData = await _clientRepo.GetClientIdNames(request.Skip, request.Take, request.FilterText);
            return pagingData;
        }
    }
}
