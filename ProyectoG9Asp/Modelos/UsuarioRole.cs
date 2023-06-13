namespace ProyectoG9Asp.Models
{
    public class UsuarioRole
    {
        public int usuario_id { get; set; }
        public Usuario Usuario { get; set; }

        public int role_id { get; set; }
        public Role Role { get; set; }
    }
}
