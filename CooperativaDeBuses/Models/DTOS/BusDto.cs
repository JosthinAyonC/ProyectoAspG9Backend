using System;

namespace CooperativaDeBuses.Models.DTOS
{
    public partial class BusDto
    {
        public int? Capacidad { get; set; }

        public string? Model { get; set; }

        public string? Marca { get; set; }

        public string? Placa { get; set; }
        public string? Status { get; set; }
    }
}
