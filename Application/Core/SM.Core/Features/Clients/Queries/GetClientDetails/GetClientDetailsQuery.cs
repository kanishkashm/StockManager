using MediatR;
using SM.Core.Features.Clients.Queries.CommonVms;

namespace SM.Core.Features.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClientVm>
    {
        public int Id { get; set; }

        public GetClientDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
