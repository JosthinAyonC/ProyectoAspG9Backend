using Microsoft.EntityFrameworkCore;

namespace CooperativaDeBuses.Models.Repositories.BusRepository
{
    public interface IBusRepository
    {
        Task<List<Bus>> GetListBus();
        Task<Bus> AddBus(Bus bus);
        Task<Bus> GetBus(int id);
        Task DeleteBus(int id);
        Task UpdateBus(Bus bus);
    }
}