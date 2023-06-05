namespace SM.Core.Features.Clients.Queries.GetClientsIdNamesPaging
{
    public class ClientsIdNamesPagingVm
    {
        public int Total { get; set; }
        public IEnumerable<ClientsIdNameListVm> Clients { get; set; } = new List<ClientsIdNameListVm>();
    }
}
