using AutoMapper;
using SM.Core.Domain;
using SM.Core.Features.Clients.Queries.CommonVms;

namespace SM.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientVm>().ReverseMap();
        }
    }
}
