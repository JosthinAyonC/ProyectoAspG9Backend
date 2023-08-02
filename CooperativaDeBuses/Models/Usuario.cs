using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CooperativaDeBuses.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El número de CI es obligatorio.")]
        public string Ci { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Status { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();

        public virtual ICollection<UsuarioViaje> UsuarioViajes { get; set; } = new List<UsuarioViaje>();
    }
}
