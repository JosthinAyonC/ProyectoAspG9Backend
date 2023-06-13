using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoG9Asp.Models
{
    public class Reservacion
    {
        public int id { get; set; }

        public int disponibilidad { get; set; }

        public bool estado { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime dechaReservacion { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string observacionRechazo { get; set; }




    }
}
