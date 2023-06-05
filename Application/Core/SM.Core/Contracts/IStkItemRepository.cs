using SM.Core.Domain;
using SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions;

namespace SM.Core.Contracts
{
    public interface IStkItemRepository : IAsyncRepository<StkItem>
    {
        Task<IEnumerable<StkItemIdCodeDescriptionsVm>> GetStkItemIdCodeDescriptions(string field);
        Task<StkItemIdCodeDescriptionsPagingVm> GetStkItemIdCodeDescriptions(string field, int skip, int take, string filterText);
    }
}
