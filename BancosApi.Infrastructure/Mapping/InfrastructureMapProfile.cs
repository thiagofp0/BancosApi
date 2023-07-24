using AutoMapper;
using BancosApi.Domain.Entities;
using BancosApi.Infrastructure.Models;

namespace BancosApi.Infrastructure.Mapping
{
    public class InfrastructureMapProfile : Profile
    {
        public InfrastructureMapProfile()
        {
            CreateMap<BankDatabaseModel, Bank>()
                .ConstructUsing(src => new(Convert.ToInt64(src.Compe), src.Document, src.LongName, src.ShortName, src.Network, src.Url, src.Products, src.DateOperationStarted, src.DatePixStarted))
                .ForAllMembers(cfg => cfg.Ignore());
        }
    }
}
