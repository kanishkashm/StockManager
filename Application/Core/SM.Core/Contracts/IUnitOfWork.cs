namespace SM.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderHeaderRepository OrderHeaders { get; }
        IOrderItemRepository OrderItems { get; }
        int Save();
    }
}
