using MediatR;

namespace SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions
{
    public class GetStkItemIdCodeDescriptionsQuery : IRequest<IEnumerable<StkItemIdCodeDescriptionsVm>>
    {
        public GetStkItemIdCodeDescriptionsQuery(string field)
        {
            Field = field;
        }

        public string Field { get; set; }
    }
}
