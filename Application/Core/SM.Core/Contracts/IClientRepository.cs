using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;
using SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging;

namespace SM.Core.Contracts
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<IEnumerable<ClientsIdNamesVm>> GetClientIdNames();
        Task<ClientsIdNamesPagingVm> GetClientIdNames(int skip, int take, string filterText);
    }
}
