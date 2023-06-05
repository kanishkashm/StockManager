using MediatR;

namespace SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions
{
    public class GetStkItemIdCodeDescriptionsQuery : IRequest<StkItemIdCodeDescriptionsPagingVm>
    {
        public GetStkItemIdCodeDescriptionsQuery(string field, int skip, int take, string filterText)
        {
            Field = field;
            Skip = skip;
            Take = take;
            FilterText = filterText;
        }

        public string Field { get; set; }
        public int Skip { get; }
        public int Take { get; }
        public string FilterText { get; }
    }
}
