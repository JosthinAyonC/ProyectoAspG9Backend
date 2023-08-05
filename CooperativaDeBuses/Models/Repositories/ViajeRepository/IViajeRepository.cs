using Microsoft.EntityFrameworkCore;

namespace CooperativaDeBuses.Models.Repositories.ViajeRepository
{
    public interface IViajeRepository
    {
        Task<List<Viaje>> GetListViaje();
        Task<Viaje> AddViaje(Viaje viaje);
        Task<Viaje> GetViaje(int id);
        Task DeleteViaje(int id);
        Task<Viaje> UpdateViaje(Viaje viaje);
    }
}