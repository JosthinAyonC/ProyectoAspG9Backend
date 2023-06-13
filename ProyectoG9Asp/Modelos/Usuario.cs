using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoG9Asp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string nombre { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string apellido { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string username { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string clave { get; set; }

        [Required]
        public string cedula { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<UsuarioRole> usuario_roles { get; set; }
    }
}
