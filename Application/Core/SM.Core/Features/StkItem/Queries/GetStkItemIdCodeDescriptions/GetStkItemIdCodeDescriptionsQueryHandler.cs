using MediatR;
using SM.Core.Contracts;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;

namespace SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions
{
    public class GetStkItemIdCodeDescriptionsQueryHandler : IRequestHandler<GetStkItemIdCodeDescriptionsQuery, StkItemIdCodeDescriptionsPagingVm>
    {
        private readonly IStkItemRepository _stkItemRepository;

        public GetStkItemIdCodeDescriptionsQueryHandler(IStkItemRepository stkItemRepository)
        {
            _stkItemRepository = stkItemRepository;
        }

        public async Task<StkItemIdCodeDescriptionsPagingVm> Handle(GetStkItemIdCodeDescriptionsQuery request, CancellationToken cancellationToken)
        {
            var stkItemList = await _stkItemRepository.GetStkItemIdCodeDescriptions(request.Field, request.Skip, request.Take, request.FilterText);
            return stkItemList;
        }
    }
}
