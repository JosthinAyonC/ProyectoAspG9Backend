using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;
using AutoMapper;

using CooperativaDeBuses.Models.Repositories.UsuarioRepository;

namespace CooperativaDeBuses.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var Usuarios = await _usuarioRepository.GetListUsuario();
                return Ok(Usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var Usuario = await _usuarioRepository.GetUsuario(id);
                if (Usuario == null)
                {
                    return NotFound();
                }
                return Usuario;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ci/{id}")]
        public async Task<ActionResult<Usuario>> GetUserByCi(string id)
        {
            try
            {
                var Usuario = await _usuarioRepository.GetByUserCi(id);
                if (Usuario == null)
                {
                    return NotFound(new {message = "No se encontro un usuario con esa cedula"});
                }
                return Usuario;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Usuario UsuarioGuardado = await _usuarioRepository.AddUsuario(Usuario);

                return Ok(new{message = "Usuario guardado exitosamente"});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuario(int id, [FromBody] UsuarioDto UsuarioDto)
        {
            try
            {
                var Usuario = _mapper.Map<Usuario>(UsuarioDto);
                Usuario.Id = id;
                var UsuarioItem = await _usuarioRepository.GetUsuario(id);

                if (UsuarioItem == null)
                {
                    return NotFound();
                }

                await _usuarioRepository.UpdateUsuario(Usuario);

                return Ok(new{message = "Usuario actualizado exitosamente"});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("eliminar/{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            try
            {
                await _usuarioRepository.DeleteUsuario(id);

                return Ok(new { message = $"Usuario con id {id} eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
    