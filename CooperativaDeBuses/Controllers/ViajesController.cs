using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;
using AutoMapper;
using CooperativaDeBuses.Models.Repositories.ViajeRepository;

namespace CooperativaDeBuses.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly IViajeRepository _viajeRepository;
        private readonly IMapper _mapper;

        public ViajesController(IViajeRepository viajeRepository, IMapper mapper)
        {
            _viajeRepository = viajeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetViajes()
        {
            try
            {
                var viajes = await _viajeRepository.GetListViaje();
                return Ok(viajes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Viaje>> GetViaje(int id)
        {
            try
            {
                var viaje = await _viajeRepository.GetViaje(id);
                if (viaje == null)
                {
                    return NotFound();
                }
                return viaje;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Viaje>> PostViaje([FromBody] Viaje viaje)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var viajeGuardado = await _viajeRepository.AddViaje(viaje);

                return Ok(new {message = "Viaje guardado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Viaje>> PutViaje(int id, [FromBody] ViajeDto viajedto)
        {
            try
            {
                var viaje = _mapper.Map<Viaje>(viajedto);
                viaje.Id = id;
                var viajeItem = await _viajeRepository.GetViaje(id);

                if (viajeItem == null)
                {
                    return NotFound();
                }

                await _viajeRepository.UpdateViaje(viaje);

                return Ok(new {message = "Viaje actualizado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("eliminar/{id}")]
        public async Task<ActionResult<Viaje>> DeleteViaje(int id)
        {
            try
            {
                await _viajeRepository.DeleteViaje(id);

                return Ok(new { message = $"Viaje con id {id} eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
