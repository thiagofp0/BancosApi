using AutoMapper;
using BancosApi.Domain.QueryObjects;
using BancosApi.Models;

namespace BancosApi.Mapping
{
    public class ApiMapProfile : Profile
    {
        public ApiMapProfile()
        {
            CreateMap<BanksRequestApiModel, CreateBankQueryObject>()
                .ConstructUsing(src => new(src.Id, src.Document, src.LongName, src.ShortName, src.Network, src.Website, src.Products, src.DateOperationStarted, src.DatePixStarted))
                .ForAllMembers(cfg => cfg.Ignore());
        }
    }
}
