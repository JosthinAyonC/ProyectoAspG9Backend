using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoG9Asp.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Usuarios",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tickets",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reservaciones",
                newName: "Estado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Usuarios",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Tickets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Reservaciones",
                newName: "Status");
        }
    }
}
