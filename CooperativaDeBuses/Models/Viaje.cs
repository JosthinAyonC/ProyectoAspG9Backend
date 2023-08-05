using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CooperativaDeBuses.Models
{
    public partial class Viaje
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El destino es obligatorio.")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateOnly Fecha { get; set; }

        public string? Observacion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "El bus es obligatorio.")]
        public int BusId { get; set; }
        public virtual Bus? Bus { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<UsuarioViaje> UsuarioViajes { get; set; } = new List<UsuarioViaje>();
    }
}
