using SM.Core.Contracts;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesManagerDbContext _dbContext;

        public UnitOfWork(SalesManagerDbContext dbContext, IOrderHeaderRepository OrderHeaderRepo, IOrderItemRepository OrderItemRepo)
        {
            _dbContext = dbContext;
            OrderHeaders = OrderHeaderRepo;
            OrderItems = OrderItemRepo;
        }

        public IOrderHeaderRepository OrderHeaders { get; }

        public IOrderItemRepository OrderItems { get; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
