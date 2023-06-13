using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoG9Asp.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservaciones_ReservacionId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRoles_Roles_RoleId",
                table: "UsuarioRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRoles_Usuarios_UsuarioId",
                table: "UsuarioRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRoles",
                table: "UsuarioRoles");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "tickets");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Reservaciones",
                newName: "reservaciones");

            migrationBuilder.RenameTable(
                name: "UsuarioRoles",
                newName: "usuario_roles");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "usuarios",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "usuarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "usuarios",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "usuarios",
                newName: "clave");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "usuarios",
                newName: "cedula");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "usuarios",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "ReservacionId",
                table: "tickets",
                newName: "Reservacionid");

            migrationBuilder.RenameColumn(
                name: "Observacion",
                table: "tickets",
                newName: "observacion");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "tickets",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tickets",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UsuarioId",
                table: "tickets",
                newName: "IX_tickets_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReservacionId",
                table: "tickets",
                newName: "IX_tickets_Reservacionid");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "roles",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "ObservacionRechazo",
                table: "reservaciones",
                newName: "observacionRechazo");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "reservaciones",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Disponibilidad",
                table: "reservaciones",
                newName: "disponibilidad");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reservaciones",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FechaReservacion",
                table: "reservaciones",
                newName: "dechaReservacion");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "usuario_roles",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "usuario_roles",
                newName: "usuario_id");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRoles_RoleId",
                table: "usuario_roles",
                newName: "IX_usuario_roles_role_id");

            migrationBuilder.AddColumn<int>(
                name: "reservacion_id",
                table: "tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usuario_id",
                table: "tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservaciones",
                table: "reservaciones",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario_roles",
                table: "usuario_roles",
                columns: new[] { "usuario_id", "role_id" });

            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estado = table.Column<bool>(type: "boolean", nullable: false),
                    capacidad = table.Column<int>(type: "integer", nullable: false),
                    placa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_reservaciones_Reservacionid",
                table: "tickets",
                column: "Reservacionid",
                principalTable: "reservaciones",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_usuarios_UsuarioId",
                table: "tickets",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_roles_roles_role_id",
                table: "usuario_roles",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_roles_usuarios_usuario_id",
                table: "usuario_roles",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_reservaciones_Reservacionid",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_usuarios_UsuarioId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_roles_roles_role_id",
                table: "usuario_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_roles_usuarios_usuario_id",
                table: "usuario_roles");

            migrationBuilder.DropTable(
                name: "buses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservaciones",
                table: "reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario_roles",
                table: "usuario_roles");

            migrationBuilder.DropColumn(
                name: "reservacion_id",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "usuario_id",
                table: "tickets");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "reservaciones",
                newName: "Reservaciones");

            migrationBuilder.RenameTable(
                name: "usuario_roles",
                newName: "UsuarioRoles");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Usuarios",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Usuarios",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "clave",
                table: "Usuarios",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "cedula",
                table: "Usuarios",
                newName: "Cedula");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "Usuarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "observacion",
                table: "Tickets",
                newName: "Observacion");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Tickets",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Reservacionid",
                table: "Tickets",
                newName: "ReservacionId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_UsuarioId",
                table: "Tickets",
                newName: "IX_Tickets_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_Reservacionid",
                table: "Tickets",
                newName: "IX_Tickets_ReservacionId");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Roles",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "observacionRechazo",
                table: "Reservaciones",
                newName: "ObservacionRechazo");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Reservaciones",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "disponibilidad",
                table: "Reservaciones",
                newName: "Disponibilidad");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reservaciones",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dechaReservacion",
                table: "Reservaciones",
                newName: "FechaReservacion");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "UsuarioRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "UsuarioRoles",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_roles_role_id",
                table: "UsuarioRoles",
                newName: "IX_UsuarioRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRoles",
                table: "UsuarioRoles",
                columns: new[] { "UsuarioId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservaciones_ReservacionId",
                table: "Tickets",
                column: "ReservacionId",
                principalTable: "Reservaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioId",
                table: "Tickets",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRoles_Roles_RoleId",
                table: "UsuarioRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRoles_Usuarios_UsuarioId",
                table: "UsuarioRoles",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
