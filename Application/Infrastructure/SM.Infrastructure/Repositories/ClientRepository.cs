using Microsoft.EntityFrameworkCore;
using SM.Core.Contracts;
using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(SalesManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClientsIdNamesVm>> GetClientIdNames()
        {
            var clientList = await _dbContext.Clients
                .Select(c => new ClientsIdNamesVm { Value = c.Dclink, Label = c.Name ?? string.Empty }).ToListAsync();
            return clientList;
        }
    }
}
