using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;
using CooperativaDeBuses.Models.Repositories.TicketRepository;
using CooperativaDeBuses.Models.Repositories.UsuarioRepository;
using AutoMapper;


namespace CooperativaDeBuses.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository ticketRepository, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _ticketRepository = ticketRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            try
            {
                var tickets = await _ticketRepository.GetListTicket();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByUserId(string id)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.GetByUserCi(id);
                if (usuario == null)
                {
                    return NotFound(new { message = "No se encontraron tickets para el usuario con cedula: " + id });
                }
                var tickets = await _ticketRepository.GetTicketsByUserId(usuario.Id);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            try
            {
                var ticket = await _ticketRepository.GetTicket(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return ticket;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket([FromBody] Ticket ticket)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _ticketRepository.AddTicket(ticket);

                return Ok(new { message = "Ticket guardado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> PutTicket(int id, [FromBody] TicketDto ticketDto)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDto);
                ticket.Id = id;
                var ticketItem = await _ticketRepository.GetTicket(id);

                if (ticketItem == null)
                {
                    return NotFound();
                }

                Ticket ticketA = await _ticketRepository.UpdateTicket(ticket);

                return Ok(new { message = "Ticket actualizado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("eliminar/{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            try
            {
                await _ticketRepository.DeleteTicket(id);

                return Ok(new { message = $"Ticket con id {id} eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
