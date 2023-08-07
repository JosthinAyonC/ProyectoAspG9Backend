using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;

namespace CooperativaDeBuses.Models.Repositories.TicketRepository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ProyectoG9aspContext _context;

        public TicketRepository(ProyectoG9aspContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetListTicket()
        {
            return await _context.Tickets.Where(ticket => ticket.Status != "N").OrderByDescending(ticket => ticket.Id).ToListAsync();
        }

        public async Task<Ticket> GetTicket(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }


        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            ticket.Status = "A";
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            Ticket ticketExistente = await _context.Tickets.FindAsync(ticket.Id);

            if (ticketExistente == null)
            {
                return null;
            }

            if (ticketExistente.Status == "N")
            {
                return null;
            }

            // if (ticket.Capacidad != 0)
            // {
            //     ticketExistente.Capacidad = ticket.Capacidad;
            // }
            // if (ticket.Model != null)
            // {
            //     ticketExistente.Model = ticket.Model;
            // }
            // if (ticket.Marca != null)
            // {
            //     ticketExistente.Marca = ticket.Marca;
            // }
            // if (ticket.Placa != null)
            // {
            //     ticketExistente.Placa = ticket.Placa;
            // }if (ticket.Status != null)
            // {
            //     ticketExistente.Status = ticket.Status;
            // }

            await _context.SaveChangesAsync();
            return ticketExistente;
        }

        public async Task DeleteTicket(int id)
        {
            Ticket ticket = await _context.Tickets.FindAsync(id);
            ticket.Status = "N";
            await _context.SaveChangesAsync();
        }

    }
}