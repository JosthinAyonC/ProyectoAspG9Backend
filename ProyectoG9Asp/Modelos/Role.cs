using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoG9Asp.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string nombre { get; set; }

        public ICollection<UsuarioRole> usuario_roles { get; set; }

    }
}
