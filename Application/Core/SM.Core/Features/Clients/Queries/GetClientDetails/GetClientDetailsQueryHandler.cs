using AutoMapper;
using MediatR;
using SM.Core.Contracts;
using SM.Core.Features.Clients.Queries.CommonVms;

namespace SM.Core.Features.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryHandler : IRequestHandler<GetClientDetailsQuery, ClientVm>
    {
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;

        public GetClientDetailsQueryHandler(
            IClientRepository clientRepo,
            IMapper mapper
        )
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task<ClientVm> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepo.GetByIdAsync(request.Id);
            var returnClient = _mapper.Map<ClientVm>( client );
            return returnClient;
        }
    }
}
