using Microsoft.EntityFrameworkCore;
using SM.Core.Contracts;
using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;
using SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging;
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

        public async Task<ClientsIdNamesPagingVm> GetClientIdNames(int skip, int take, string filterText)
        {
            var clientList = await _dbContext.Clients
                .Where(x => string.IsNullOrEmpty(filterText) || string.IsNullOrEmpty(x.Name) || x.Name.ToLower().Contains(filterText))
                .ToListAsync();
            var total = clientList.Count;
            var clientIdList = clientList.Skip(skip).Take(take).Select(cl => new ClientsIdNameListVm
            {
                Dclink = cl.Dclink,
                Name = cl.Name ?? string.Empty,
            });
            var returnData = new ClientsIdNamesPagingVm
            {
                Total = total,
                Clients = clientIdList
            };
            return returnData;
        }
    }
}
