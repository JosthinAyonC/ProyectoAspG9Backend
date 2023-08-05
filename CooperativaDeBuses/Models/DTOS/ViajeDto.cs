using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CooperativaDeBuses.Models
{
    public partial class ViajeDto
    {
        public int? Id { get; set; }

        public string? Destino { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Observacion { get; set; }

        public decimal? Precio { get; set; }

        public string? Status { get; set; }

        public int? IdBus { get; set; }
        public virtual Bus? Bus { get; set; }
    }
}
