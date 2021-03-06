using AutoMapper;
using EnergyPrices.Dtos;
using EnergyPrices.Models;

namespace EnergyPrices.Profiles
{
    public class EnergyPriceProfile : Profile
    {
        public EnergyPriceProfile()
        {
            CreateMap<EnergyPrice, EnergyPriceReadDTO>();
            CreateMap<EnergyPriceCreateDTO, EnergyPrice>().ForMember(x => x.Id, opt => opt.Ignore());
        }
        

    }
}
