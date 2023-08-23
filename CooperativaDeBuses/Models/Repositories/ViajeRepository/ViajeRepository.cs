using Microsoft.EntityFrameworkCore;
using CooperativaDeBuses.Models;

namespace CooperativaDeBuses.Models.Repositories.ViajeRepository
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly ProyectoG9aspContext _context;

        public ViajeRepository(ProyectoG9aspContext context)
        {
            _context = context;
        }

        public async Task<List<Viaje>> GetListViaje()
        {
            return await _context.Viajes.Where(viaje => viaje.Status != "N").OrderByDescending(viaje => viaje.Id).ToListAsync();
        }

        public async Task<Viaje> GetViaje(int id)
        {
            return await _context.Viajes.FindAsync(id);
        }


        public async Task<Viaje> AddViaje(Viaje viaje)
        {
            viaje.Status = "A";
            Bus bus = await _context.Buses.FindAsync(viaje.BusId);
            viaje.Bus = bus;
            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();
            return viaje;
        }

        public async Task<Viaje> UpdateViaje(Viaje viaje)
        {
            Viaje viajeExistente = await _context.Viajes.FindAsync(viaje.Id);

            if (viajeExistente == null)
            {
                return null;
            }

            if (viajeExistente.Status == "N")
            {
                return null;
            }

            if (viaje.BusId != 0)
            {
                viajeExistente.Bus = await _context.Buses.FindAsync(viaje.BusId);
                viajeExistente.BusId = viaje.BusId;
            }

            if (viaje.Observacion != null)
            {
                viajeExistente.Observacion = viaje.Observacion;
            }

            if (viaje.Precio != null)
            {
                viajeExistente.Precio = viaje.Precio;
            }

            if (viaje.Destino != null)
            {
                viajeExistente.Destino = viaje.Destino;
            }

            if (viaje.Fecha != null && viaje.Fecha != new DateOnly(1, 1, 1))
            {
                viajeExistente.Fecha = viaje.Fecha;
            }

            await _context.SaveChangesAsync();
            return viajeExistente;
        }


        public async Task DeleteViaje(int id)
        {
            Viaje viaje = await _context.Viajes.FindAsync(id);
            viaje.Status = "N";
            await _context.SaveChangesAsync();
        }

    }
}