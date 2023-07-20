using AutoMapper;
using BancosApi.Domain.Entities;
using BancosApi.Infrastructure.Models;

namespace BancosApi.Infrastructure.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BankDatabaseModel, Bank>()
                .ConstructUsing(src => new(Convert.ToInt64(src.Compe), src.Document, src.LongName, src.ShortName))
                .ForAllMembers(cfg => cfg.Ignore());
        }
    }
}
