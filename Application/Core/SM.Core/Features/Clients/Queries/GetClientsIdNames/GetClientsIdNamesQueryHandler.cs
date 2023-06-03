using AutoMapper;
using MediatR;
using SM.Core.Contracts;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;

namespace SM.Core.Features.Clients.Queries.GetClientsList
{
    public class GetClientsIdNamesQueryHandler : IRequestHandler<GetClientsIdNamesQuery, IEnumerable<ClientsIdNamesVm>>
    {
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;

        public GetClientsIdNamesQueryHandler(IClientRepository clientRepo
            , IMapper mapper
            )
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientsIdNamesVm>> Handle(GetClientsIdNamesQuery request, CancellationToken cancellationToken)
        {
            var clientList = await _clientRepo.GetClientIdNames();
            return clientList;
        }
    }
}
