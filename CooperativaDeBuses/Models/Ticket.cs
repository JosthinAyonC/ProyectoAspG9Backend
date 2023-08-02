using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CooperativaDeBuses.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Id del Viaje es obligatorio.")]
        public int IdViaje { get; set; }

        [Required(ErrorMessage = "El Id del Usuario es obligatorio.")]
        public int IdUsuario { get; set; }

        public string? Observacion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "El Usuario es obligatorio.")]
        public virtual Usuario IdUsuarioNavigation { get; set; }

        [Required(ErrorMessage = "El Viaje es obligatorio.")]
        public virtual Viaje IdViajeNavigation { get; set; }
    }
}
