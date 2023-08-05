using AutoMapper;
using CooperativaDeBuses.Models.DTOS;

namespace CooperativaDeBuses.Models.Profiles
{
    public class ViajeProfile: Profile
    {
        public ViajeProfile()
        {
            CreateMap<Viaje, ViajeDto>();
            CreateMap<ViajeDto, Viaje>();
        }
    }
}
