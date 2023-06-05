using AutoMapper;
using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.CommonVms;
using SM.Core.Features.Order.Command;
using SM.Core.Features.StkItem.Queries.GetStockItemDetals;

namespace SM.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientVm>().ReverseMap();
            CreateMap<StkItem, StockItemDetalsVm>().ReverseMap();
            CreateMap<OrderCommand, OrderHeader>().ReverseMap();
            CreateMap<OrderItemCommand, OrderItem>().ReverseMap();
        }
    }
}
