using SM.Core.Domain;
using SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions;

namespace SM.Core.Contracts
{
    public interface IStkItemRepository : IAsyncRepository<StkItem>
    {
        Task<IEnumerable<StkItemIdCodeDescriptionsVm>> GetStkItemIdCodeDescriptions(string field);
    }
}
