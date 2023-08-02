using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;
using CooperativaDeBuses.Models.Repositories.BusRepository;

namespace CooperativaDeBuses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBusRepository _busRepository;

        public BusesController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
            try
            {
                var buses = await _busRepository.GetListBus();
                return buses;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            try
            {
                var bus = await _busRepository.GetBus(id);
                if (bus == null)
                {
                    return NotFound();
                }
                return bus;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus([FromBody] Bus bus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var busGuardado = await _busRepository.AddBus(bus);

                return CreatedAtAction(nameof(GetBus), new { id = busGuardado.Id }, busGuardado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, [FromBody] Bus bus)
        {
            try
            {
                var busItem = await _busRepository.GetBus(id);

                if (busItem == null)
                {
                    return NotFound();
                }

                await _busRepository.UpdateBus(bus);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("eliminar/{id}")]
        public async Task<ActionResult<Bus>> DeleteBus(int id)
        {
            try
            {
                await _busRepository.DeleteBus(id);

                return Ok("Usuario con id " + id + " eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
