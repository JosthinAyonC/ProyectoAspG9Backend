using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CooperativaDeBuses.Models
{
    public partial class Bus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La capacidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad debe ser un número positivo.")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria.")]
        public string Placa { get; set; }
        public string Status { get; set; }
    }
}
