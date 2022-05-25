using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Data.Migrations
{
    public partial class agregfaciondepublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    idPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.idPais);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    idProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProvincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.idProvincia);
                    table.ForeignKey(
                        name: "FK_Provincia_Pais_PaisidPais",
                        column: x => x.PaisidPais,
                        principalTable: "Pais",
                        principalColumn: "idPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    idLocalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<int>(type: "int", nullable: false),
                    ProvinciaidProvincia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.idLocalidad);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_ProvinciaidProvincia",
                        column: x => x.ProvinciaidProvincia,
                        principalTable: "Provincia",
                        principalColumn: "idProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_ProvinciaidProvincia",
                table: "Localidad",
                column: "ProvinciaidProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PaisidPais",
                table: "Provincia",
                column: "PaisidPais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
