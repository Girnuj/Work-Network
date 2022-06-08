using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Data.Migrations
{
    public partial class CampoIDPcias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPais",
                table: "Provincia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idProvincia",
                table: "Localidad",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idPais",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "idProvincia",
                table: "Localidad");
        }
    }
}
