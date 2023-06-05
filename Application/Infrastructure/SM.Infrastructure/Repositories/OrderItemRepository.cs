using SM.Core.Contracts;
using SM.Core.Domain;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(SalesManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
