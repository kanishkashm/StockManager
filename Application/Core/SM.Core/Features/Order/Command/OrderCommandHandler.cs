using AutoMapper;
using MediatR;
using SM.Core.Contracts;
using SM.Core.Domain;

namespace SM.Core.Features.Order.Command
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<Unit> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderHeaderEntity = _mapper.Map<OrderHeader>(request);
                await _unitOfWork.OrderHeaders.AddAsync(orderHeaderEntity);
                var orderItemEntityList = _mapper.Map<List<OrderItem>>(request.OrderItems);
                orderItemEntityList.ForEach(x => x.OrderHeaderId = orderHeaderEntity.OrderId);
                await _unitOfWork.OrderItems.AddAsync(orderItemEntityList);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                //log exception

            }
            return Unit.Value;
        }
    }
}
