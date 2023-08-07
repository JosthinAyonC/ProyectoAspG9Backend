using AutoMapper;
using CooperativaDeBuses.Models.DTOS;

namespace CooperativaDeBuses.Models.Profiles
{
    public class UsuarioProfile: Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
