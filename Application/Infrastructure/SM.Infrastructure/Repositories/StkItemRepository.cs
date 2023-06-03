using Microsoft.EntityFrameworkCore;
using SM.Core.Contracts;
using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;
using SM.Core.Features.StkItem.Queries.GetStkItemIdCodeDescriptions;
using SM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.Repositories
{
    public class StkItemRepository : RepositoryBase<StkItem>, IStkItemRepository
    {
        public StkItemRepository(SalesManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<StkItemIdCodeDescriptionsVm>> GetStkItemIdCodeDescriptions(string field)
        {
            var clientList = await _dbContext.StkItems
                .Select(si => new StkItemIdCodeDescriptionsVm
                {
                    Value = si.StockLink,
                    Label = (string)si.GetType().GetProperty(field).GetValue(si, null) ?? string.Empty
                })
                .ToListAsync();
            return clientList;
        }
    }
}
