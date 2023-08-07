using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;

namespace CooperativaDeBuses.Models.Repositories.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProyectoG9aspContext _context;

        public UsuarioRepository(ProyectoG9aspContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetListUsuario()
        {
            return await _context.Usuarios.Where(usuario => usuario.Status != "N").OrderByDescending(usuario => usuario.Id).ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }


        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            usuario.Status = "A";
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UdateUusuario(Usuario usuario)
        {
            usuario usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);

            if (usuarioExistente == null)
            {
                return null;
            }

            if (usuarioExistente.Status == "N")
            {
                return null;
            }

            // if (usuario.Capacidad != 0)
            // {
            //     usuarioExistente.Capacidad = usuario.Capacidad;
            // }
            // if (usuario.Model != null)
            // {
            //     usuarioExistente.Model = usuario.Model;
            // }
            // if (usuario.Marca != null)
            // {
            //     usuarioExistente.Marca = usuario.Marca;
            // }
            // if (usuario.Placa != null)
            // {
            //     usuarioExistente.Placa = usuario.Placa;
            // }if (usuario.Status != null)
            // {
            //     usuarioExistente.Status = usuario.Status;
            // }

            await _context.SaveChangesAsync();
            return usuarioExistente;
        }

        public async Task DeleteUsuario(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
            usuario.Status = "N";
            await _context.SaveChangesAsync();
        }

    }
}