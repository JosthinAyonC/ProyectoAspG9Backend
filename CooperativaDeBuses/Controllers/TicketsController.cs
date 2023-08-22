using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;
using CooperativaDeBuses.Models.Repositories.TicketRepository;
using AutoMapper;


namespace CooperativaDeBuses.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
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
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByUserId()
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

                return Ok(ticketA);

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
