using AutoMapper;
using MediatR;
using SM.Core.Contracts;
using SM.Core.Features.Clients.Queries.CommonVms;

namespace SM.Core.Features.Clients.Queries.GetClientsList
{
    public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, List<ClientVm>>
    {
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;

        public GetClientsListQueryHandler(IClientRepository clientRepo
            , IMapper mapper
            )
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task<List<ClientVm>> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
        {
            var clientList = await _clientRepo.GetAllAsync();
            var returnList = _mapper.Map<List<ClientVm>>(clientList);
            return returnList;
        }
    }
}
