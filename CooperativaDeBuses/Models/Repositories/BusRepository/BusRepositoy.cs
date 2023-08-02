using Microsoft.EntityFrameworkCore;

namespace CooperativaDeBuses.Models.Repositories.BusRepository
{
    public class BusRepository : IBusRepository
    {
        private readonly ProyectoG9aspContext _context;

        public async Task<List<Bus>> GetListBus()
        {
            return await _context.Buses.ToListAsync();
        }

        public async Task<Bus> GetBus(int id)
        {
            return await _context.Buses.FindAsync(id);
        }


        public async Task<Bus> AddBus(Bus bus)
        {
            bus.Status = "A";
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task UpdateBus(Bus bus)
        {
            var busItem = await _context.Buses.FirstOrDefaultAsync(x => x.Id == bus.Id);

            if(busItem != null)
            {
                busItem.Capacidad = bus.Capacidad;
                busItem.Model = bus.Model;
                busItem.Marca = bus.Marca;
                busItem.Placa = bus.Placa;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteBus(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            bus.Status = "N";
            await _context.SaveChangesAsync();
        }
        
    }
}