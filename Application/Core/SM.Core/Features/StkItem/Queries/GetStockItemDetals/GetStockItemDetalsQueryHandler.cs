using AutoMapper;
using MediatR;
using SM.Core.Contracts;
using SM.Core.Features.Clients.Queries.CommonVms;

namespace SM.Core.Features.StkItem.Queries.GetStockItemDetals
{
    public class GetStockItemDetalsQueryHandler : IRequestHandler<GetStockItemDetalsQuery, StockItemDetalsVm>
    {
        private readonly IStkItemRepository _stkItemRepository;
        private readonly IMapper _mapper;

        public GetStockItemDetalsQueryHandler(IStkItemRepository stkItemRepository, IMapper mapper)
        {
            _stkItemRepository = stkItemRepository;
            _mapper = mapper;
        }

        public async Task<StockItemDetalsVm> Handle(GetStockItemDetalsQuery request, CancellationToken cancellationToken)
        {
            var stockItemFromDb = await _stkItemRepository.GetByIdAsync(request.StockLink);
            var stockItem = _mapper.Map<StockItemDetalsVm>(stockItemFromDb);
            return stockItem;
        }
    }
}
