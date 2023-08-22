using Microsoft.EntityFrameworkCore;

namespace CooperativaDeBuses.Models.Repositories.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetListUsuario();
        Task<Usuario> AddUsuario(Usuario Usuario);
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> GetByUserCi(string id);
        Task DeleteUsuario(int id);
        Task<Usuario> UpdateUsuario(Usuario bus);
    }
}