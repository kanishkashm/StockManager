using MediatR;

namespace SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging
{
    public class GetClientsIdNamesPagingQuery : IRequest<ClientsIdNamesPagingVm>
    {
        public GetClientsIdNamesPagingQuery(int skip, int take, string filterText)
        {
            Skip = skip;
            Take = take;
            FilterText = filterText;
        }

        public int Skip { get; }
        public int Take { get; }
        public string FilterText { get; }
    }
}
