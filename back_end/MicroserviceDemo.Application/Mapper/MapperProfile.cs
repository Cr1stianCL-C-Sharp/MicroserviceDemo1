using AutoMapper;
using VirtualMind.Application.Dtos;
using VirtualMind.Core.Entities;

namespace VirtualMind.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CurrencyEntity, CurrencyDto>();
            CreateMap<CurrencyBuyDto, CurrencyBuyEntity>();

        }


    }
}