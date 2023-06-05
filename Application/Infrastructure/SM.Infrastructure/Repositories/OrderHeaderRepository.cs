using SM.Core.Contracts;
using SM.Core.Domain;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories
{
    public class OrderHeaderRepository : RepositoryBase<OrderHeader>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(SalesManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
