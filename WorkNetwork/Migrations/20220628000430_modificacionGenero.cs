using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class modificacionGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacante_DisponibilidadHoraria_DisponibilidadHorariaID",
                table: "Vacante");

            migrationBuilder.DropTable(
                name: "DisponibilidadHoraria");

            migrationBuilder.DropIndex(
                name: "IX_Vacante_DisponibilidadHorariaID",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "DisponibilidadHorariaID",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisponibilidadHorariaID",
                table: "Vacante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DisponibilidadHoraria",
                columns: table => new
                {
                    DisponibilidadHorariaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadHoraria", x => x.DisponibilidadHorariaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_DisponibilidadHorariaID",
                table: "Vacante",
                column: "DisponibilidadHorariaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacante_DisponibilidadHoraria_DisponibilidadHorariaID",
                table: "Vacante",
                column: "DisponibilidadHorariaID",
                principalTable: "DisponibilidadHoraria",
                principalColumn: "DisponibilidadHorariaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
