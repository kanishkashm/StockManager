using Microsoft.EntityFrameworkCore;
using SM.Core.Contracts;
using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.GetClientsIdNames;
using SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging;
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
                    Text = (string)si.GetType().GetProperty(field).GetValue(si, null) ?? string.Empty
                })
                .ToListAsync();
            return clientList;
        }

        public async Task<StkItemIdCodeDescriptionsPagingVm> GetStkItemIdCodeDescriptions(string field, int skip, int take, string filterText)
        {
            //var dbList = _dbContext.StkItems.ToList()
            //    .Where(x => string.IsNullOrEmpty(filterText) || string.IsNullOrEmpty((string)x.GetType().GetProperty(field).GetValue(x, null)) || ((string)x.GetType().GetProperty(field).GetValue(x, null)).ToLower().Contains(filterText))
            //    .Select(si => new StkItemIdCodeDescriptionsVm
            //    {
            //        Value = si.StockLink,
            //        Text = (string)si.GetType().GetProperty(field).GetValue(si, null) ?? string.Empty
            //    });
            //var total = dbList.Count();
            //var items = dbList.Skip(skip).Take(take).Select(i => new StkItemIdCodeDescriptionsVm
            //{
            //    Text = i.Text ?? string.Empty,
            //    Value = i.Value,
            //});
            //var returnData = new StkItemIdCodeDescriptionsPagingVm
            //{
            //    Total = total,
            //    List = items
            //};
            var dbList = new List<StkItem>();
            if (field == "Code")
            {
                dbList = await _dbContext.StkItems
                .Where(x => string.IsNullOrEmpty(filterText) || string.IsNullOrEmpty(x.Code) || x.Code.ToLower().Contains(filterText))
                .ToListAsync();
            }
            else if (field == "Description1")
            {
                dbList = await _dbContext.StkItems
               .Where(x => string.IsNullOrEmpty(filterText) || string.IsNullOrEmpty(x.Description1) || x.Description1.ToLower().Contains(filterText))
               .ToListAsync();
            }
            var total = dbList.Count;
            var items = dbList.Skip(skip).Take(take).Select(si => new StkItemIdCodeDescriptionsVm
            {
                Value = si.StockLink,
                Text = field == "Code" ? (si.Code ?? string.Empty) : (field == "Description1" ? (si.Description1 ?? string.Empty) : (string.Empty)),
            });
            var returnData = new StkItemIdCodeDescriptionsPagingVm
            {
                Total = total,
                List = items
            };

            return returnData;
        }
    }
}
