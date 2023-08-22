using Microsoft.EntityFrameworkCore;

namespace CooperativaDeBuses.Models.Repositories.TicketRepository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetListTicket();
        Task<List<Ticket>> GetTicketsByUserId(int id);
        Task<Ticket> AddTicket(Ticket Ticket);
        Task<Ticket> GetTicket(int id);
        Task DeleteTicket(int id);
        Task<Ticket> UpdateTicket(Ticket bus);
    }
}