namespace SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions
{
    public class StkItemIdCodeDescriptionsPagingVm
    {
        public int Total { get; set; }
        public IEnumerable<StkItemIdCodeDescriptionsVm> List { get; set; } = new List<StkItemIdCodeDescriptionsVm>();
    }
}
