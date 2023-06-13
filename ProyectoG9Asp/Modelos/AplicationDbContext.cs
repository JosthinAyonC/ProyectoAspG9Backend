using Microsoft.EntityFrameworkCore;
using ProyectoG9Asp.Models;

namespace ProyectoG9Asp.Models
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRole>()
                .HasKey(ur => new { ur.usuario_id, ur.role_id });

            modelBuilder.Entity<UsuarioRole>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.usuario_roles)
                .HasForeignKey(ur => ur.usuario_id);

            modelBuilder.Entity<UsuarioRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.usuario_roles)
                .HasForeignKey(ur => ur.role_id);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UsuarioRole> usuario_roles { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Reservacion> reservaciones { get; set; }
        public DbSet<Bus> buses { get; set; }
    }
}
