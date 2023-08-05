using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;

namespace CooperativaDeBuses.Models.Repositories.BusRepository
{
    public class BusRepository : IBusRepository
    {
        private readonly ProyectoG9aspContext _context;

        public BusRepository(ProyectoG9aspContext context)
        {
            _context = context;
        }

        public async Task<List<Bus>> GetListBus()
        {
            return await _context.Buses.Where(bus => bus.Status != "N").OrderByDescending(bus => bus.Id).ToListAsync();
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

        public async Task<Bus> UpdateBus(Bus bus)
        {
            // Buscar el autobús existente en la base de datos por su Id
            Bus busExistente = await _context.Buses.FindAsync(bus.Id);

            // Si no se encuentra el autobús, retornar null
            if (busExistente == null)
            {
                return null;
            }

            // Verificar que el autobús no esté en estado "N"
            if (busExistente.Status == "N")
            {
                return null;
            }

            // Actualizar los campos del autobús existente con los valores proporcionados en el parámetro "bus"
            if (bus.Capacidad != 0)
            {
                busExistente.Capacidad = bus.Capacidad;
            }
            if (bus.Model != null)
            {
                busExistente.Model = bus.Model;
            }
            if (bus.Marca != null)
            {
                busExistente.Marca = bus.Marca;
            }
            if (bus.Placa != null)
            {
                busExistente.Placa = bus.Placa;
            }if (bus.Status != null)
            {
                busExistente.Status = bus.Status;
            }

            await _context.SaveChangesAsync();
            // Retornar el objeto "busExistente" actualizado
            return busExistente;
        }

        public async Task DeleteBus(int id)
        {
            Bus bus = await _context.Buses.FindAsync(id);
            bus.Status = "N";
            await _context.SaveChangesAsync();
        }

    }
}