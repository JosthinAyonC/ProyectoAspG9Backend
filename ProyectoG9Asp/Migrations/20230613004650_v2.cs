using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoG9Asp.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservacion_ReservacionId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservacion",
                table: "Reservacion");

            migrationBuilder.RenameTable(
                name: "Reservacion",
                newName: "Reservaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservaciones_ReservacionId",
                table: "Tickets",
                column: "ReservacionId",
                principalTable: "Reservaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservaciones_ReservacionId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones");

            migrationBuilder.RenameTable(
                name: "Reservaciones",
                newName: "Reservacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservacion",
                table: "Reservacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservacion_ReservacionId",
                table: "Tickets",
                column: "ReservacionId",
                principalTable: "Reservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
