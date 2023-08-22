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
            return await _context.Usuarios.FindAsync(id);
        }


        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            usuario.Status = "A";
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            Usuario usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);

            if (usuarioExistente == null)
            {
                return null;
            }

            if (usuarioExistente.Status == "N")
            {
                return null;
            }

            if (usuario.Firstname != null)
            {
                usuarioExistente.Firstname = usuario.Firstname;
            }
            if (usuario.Lastname != null)
            {
                usuarioExistente.Lastname = usuario.Lastname;
            }
            if (usuario.UsuarioRoles != null)
            {
                usuarioExistente.UsuarioRoles = usuario.UsuarioRoles;
            }
            if (usuario.Ci != null)
            {
                usuarioExistente.Ci = usuario.Ci;
            }
            if (usuario.Username != null)
            {
                usuarioExistente.Username = usuario.Username;
            }if (usuario.Status != null)
            {
                usuarioExistente.Status = usuario.Status;
            }

            await _context.SaveChangesAsync();
            return usuarioExistente;
        }

        public async Task DeleteUsuario(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
            usuario.Status = "N";
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetByUserCi(string id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Ci == id);
        }
    }
}