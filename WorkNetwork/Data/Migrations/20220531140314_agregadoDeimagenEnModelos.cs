using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Data.Migrations
{
    public partial class agregadoDeimagenEnModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagen",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imagen",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Empresa");
        }
    }
}
