using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoG9Asp.Models
{
    public class Ticket
    {
        public int id { get; set; }

        public int usuario_id { get; set; }
        public Usuario Usuario { get; set; }

        public int reservacion_id { get; set; }
        public Reservacion Reservacion { get; set; }

        public bool estado { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string observacion { get; set; }

    }
}
