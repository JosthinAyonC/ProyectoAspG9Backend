using AutoMapper;
using CooperativaDeBuses.Models.DTOS;

namespace CooperativaDeBuses.Models.Profiles
{
    public class BusProfile: Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, BusDto>();
            CreateMap<BusDto, Bus>();
        }
    }
}
