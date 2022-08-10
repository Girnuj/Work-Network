using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class CampoEliminadoPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisponibilidadHoraria",
                table: "Vacante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoModalidad",
                table: "Vacante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Pais",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisponibilidadHoraria",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "tipoModalidad",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Pais");
        }
    }
}
