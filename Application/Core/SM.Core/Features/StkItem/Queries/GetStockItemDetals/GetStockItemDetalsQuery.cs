using MediatR;

namespace SM.Core.Features.StkItem.Queries.GetStockItemDetals
{
    public class GetStockItemDetalsQuery : IRequest<StockItemDetalsVm>
    {
        public GetStockItemDetalsQuery(int stockLink)
        {
            StockLink = stockLink;
        }

        public int StockLink { get; }
    }
}
