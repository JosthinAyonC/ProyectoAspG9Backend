using AutoMapper;
using CooperativaDeBuses.Models.DTOS;

namespace CooperativaDeBuses.Models.Profiles
{
    public class TicketProfile: Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();
        }
    }
}
