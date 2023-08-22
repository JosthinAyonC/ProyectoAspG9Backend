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
            return await _context.Tickets.FindAsync(id);
        }


        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            ticket.Status = "A";

            ticket.IdUsuarioNavigation = await _context.Usuarios.FindAsync(ticket.IdUsuario);

            ticket.IdViajeNavigation = await _context.Viajes.FindAsync(ticket.IdViaje);

            _context.Tickets.Add(ticket);

            Viaje viaje = await _context.Viajes.FindAsync(ticket.IdViaje);

            Bus bus = await _context.Buses.FindAsync(viaje.BusId);

            bus.Capacidad = bus.Capacidad - 1;

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

            if (ticket.IdUsuario != 0 || ticket.IdUsuario != null)
            {
                ticketExistente.IdUsuario = ticket.IdUsuario;
            }
            if (ticket.IdViaje != 0 || ticket.IdViaje != null)
            {
                ticketExistente.IdViaje = ticket.IdViaje;
            }
            if (ticket.Observacion != null)
            {
                ticketExistente.Observacion = ticket.Observacion;
            }
            if (ticket.Status != null)
            {
                ticketExistente.Status = ticket.Status;
            }

            await _context.SaveChangesAsync();
            return ticketExistente;
        }


        public async Task DeleteTicket(int id)
        {
            Ticket ticket = await _context.Tickets.FindAsync(id);
            ticket.Status = "N";
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ticket>> GetTicketsByUserId(int id)
        {
            return await _context.Tickets.Where(ticket => ticket.IdUsuario == id).ToListAsync();
        }
    }
}