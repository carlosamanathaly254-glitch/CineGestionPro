using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineGestionPro.API.Migrations
{
    /// <inheritdoc />
    public partial class V03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquileres_Usuarios_id_usuario",
                table: "Alquileres");

            migrationBuilder.AlterColumn<int>(
                name: "id_usuario",
                table: "Alquileres",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquileres_Usuarios_id_usuario",
                table: "Alquileres",
                column: "id_usuario",
                principalTable: "Usuarios",
                principalColumn: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquileres_Usuarios_id_usuario",
                table: "Alquileres");

            migrationBuilder.AlterColumn<int>(
                name: "id_usuario",
                table: "Alquileres",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alquileres_Usuarios_id_usuario",
                table: "Alquileres",
                column: "id_usuario",
                principalTable: "Usuarios",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
