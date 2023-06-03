using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;

namespace SM.Core.Contracts
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<IEnumerable<ClientsIdNamesVm>> GetClientIdNames();
    }
}
