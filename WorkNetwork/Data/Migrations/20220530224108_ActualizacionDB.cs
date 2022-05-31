using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Data.Migrations
{
    public partial class ActualizacionDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaidProvincia",
                table: "Localidad");

            migrationBuilder.AlterColumn<string>(
                name: "nombreProvincia",
                table: "Provincia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nombrePais",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nombreLocalidad",
                table: "Localidad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaidProvincia",
                table: "Localidad",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DisponibilidadHoraria",
                columns: table => new
                {
                    idDisponibilidadHoraria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadHoraria", x => x.idDisponibilidadHoraria);
                });

            migrationBuilder.CreateTable(
                name: "Rubro",
                columns: table => new
                {
                    idRubro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRubro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.idRubro);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    idEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUIT = table.Column<int>(type: "int", nullable: false),
                    numeroDeDocumento = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idLocalidad = table.Column<int>(type: "int", nullable: false),
                    LocalidadidLocalidad = table.Column<int>(type: "int", nullable: true),
                    telefono1 = table.Column<int>(type: "int", nullable: false),
                    telefono2 = table.Column<int>(type: "int", nullable: false),
                    idRubro = table.Column<int>(type: "int", nullable: false),
                    RubroidRubro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.idEmpresa);
                    table.ForeignKey(
                        name: "FK_Empresa_Localidad_LocalidadidLocalidad",
                        column: x => x.LocalidadidLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "idLocalidad");
                    table.ForeignKey(
                        name: "FK_Empresa_Rubro_RubroidRubro",
                        column: x => x.RubroidRubro,
                        principalTable: "Rubro",
                        principalColumn: "idRubro");
                });

            migrationBuilder.CreateTable(
                name: "SubRubro",
                columns: table => new
                {
                    idSubRubro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreSubRubro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idRubro = table.Column<int>(type: "int", nullable: false),
                    RubroidRubro = table.Column<int>(type: "int", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRubro", x => x.idSubRubro);
                    table.ForeignKey(
                        name: "FK_SubRubro_Rubro_RubroidRubro",
                        column: x => x.RubroidRubro,
                        principalTable: "Rubro",
                        principalColumn: "idRubro");
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidoPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroDocumento = table.Column<int>(type: "int", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    domicilioPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idLocalidad = table.Column<int>(type: "int", nullable: false),
                    LocalidadidLocalidad = table.Column<int>(type: "int", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono1 = table.Column<int>(type: "int", nullable: false),
                    telefono2 = table.Column<int>(type: "int", nullable: false),
                    estadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tituloAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idSubRubro = table.Column<int>(type: "int", nullable: false),
                    SubRubroidSubRubro = table.Column<int>(type: "int", nullable: true),
                    cantidadHijos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idPersona);
                    table.ForeignKey(
                        name: "FK_Persona_Localidad_LocalidadidLocalidad",
                        column: x => x.LocalidadidLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "idLocalidad");
                    table.ForeignKey(
                        name: "FK_Persona_SubRubro_SubRubroidSubRubro",
                        column: x => x.SubRubroidSubRubro,
                        principalTable: "SubRubro",
                        principalColumn: "idSubRubro");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    idEmpresa = table.Column<int>(type: "int", nullable: false),
                    EmpresaidEmpresa = table.Column<int>(type: "int", nullable: true),
                    password = table.Column<int>(type: "int", nullable: false),
                    ultActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_EmpresaidEmpresa",
                        column: x => x.EmpresaidEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa");
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona");
                });

            migrationBuilder.CreateTable(
                name: "Vacante",
                columns: table => new
                {
                    idVacante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEmpresa = table.Column<int>(type: "int", nullable: false),
                    EmpresaidEmpresa = table.Column<int>(type: "int", nullable: true),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experienciaRequerida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idSubrubro = table.Column<int>(type: "int", nullable: false),
                    SubRubroidSubRubro = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<int>(type: "int", nullable: false),
                    LocalidadidLocalidad = table.Column<int>(type: "int", nullable: true),
                    fechaDeFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idiomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idDisponibilidadHoraria = table.Column<int>(type: "int", nullable: false),
                    DisponibilidadHorariaidDisponibilidadHoraria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacante", x => x.idVacante);
                    table.ForeignKey(
                        name: "FK_Vacante_DisponibilidadHoraria_DisponibilidadHorariaidDisponibilidadHoraria",
                        column: x => x.DisponibilidadHorariaidDisponibilidadHoraria,
                        principalTable: "DisponibilidadHoraria",
                        principalColumn: "idDisponibilidadHoraria");
                    table.ForeignKey(
                        name: "FK_Vacante_Empresa_EmpresaidEmpresa",
                        column: x => x.EmpresaidEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa");
                    table.ForeignKey(
                        name: "FK_Vacante_Localidad_LocalidadidLocalidad",
                        column: x => x.LocalidadidLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "idLocalidad");
                    table.ForeignKey(
                        name: "FK_Vacante_Persona_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona");
                    table.ForeignKey(
                        name: "FK_Vacante_SubRubro_SubRubroidSubRubro",
                        column: x => x.SubRubroidSubRubro,
                        principalTable: "SubRubro",
                        principalColumn: "idSubRubro");
                });

            migrationBuilder.CreateTable(
                name: "PersonaVacante",
                columns: table => new
                {
                    idPersonaVacante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    idVacante = table.Column<int>(type: "int", nullable: false),
                    VacanteidVacante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaVacante", x => x.idPersonaVacante);
                    table.ForeignKey(
                        name: "FK_PersonaVacante_Persona_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona");
                    table.ForeignKey(
                        name: "FK_PersonaVacante_Vacante_VacanteidVacante",
                        column: x => x.VacanteidVacante,
                        principalTable: "Vacante",
                        principalColumn: "idVacante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_LocalidadidLocalidad",
                table: "Empresa",
                column: "LocalidadidLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_RubroidRubro",
                table: "Empresa",
                column: "RubroidRubro");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalidadidLocalidad",
                table: "Persona",
                column: "LocalidadidLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_SubRubroidSubRubro",
                table: "Persona",
                column: "SubRubroidSubRubro");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaVacante_PersonaidPersona",
                table: "PersonaVacante",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaVacante_VacanteidVacante",
                table: "PersonaVacante",
                column: "VacanteidVacante");

            migrationBuilder.CreateIndex(
                name: "IX_SubRubro_RubroidRubro",
                table: "SubRubro",
                column: "RubroidRubro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaidEmpresa",
                table: "Usuario",
                column: "EmpresaidEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PersonaidPersona",
                table: "Usuario",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_DisponibilidadHorariaidDisponibilidadHoraria",
                table: "Vacante",
                column: "DisponibilidadHorariaidDisponibilidadHoraria");

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_EmpresaidEmpresa",
                table: "Vacante",
                column: "EmpresaidEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_LocalidadidLocalidad",
                table: "Vacante",
                column: "LocalidadidLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_PersonaidPersona",
                table: "Vacante",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_SubRubroidSubRubro",
                table: "Vacante",
                column: "SubRubroidSubRubro");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaidProvincia",
                table: "Localidad",
                column: "ProvinciaidProvincia",
                principalTable: "Provincia",
                principalColumn: "idProvincia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaidProvincia",
                table: "Localidad");

            migrationBuilder.DropTable(
                name: "PersonaVacante");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vacante");

            migrationBuilder.DropTable(
                name: "DisponibilidadHoraria");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "SubRubro");

            migrationBuilder.DropTable(
                name: "Rubro");

            migrationBuilder.AlterColumn<string>(
                name: "nombreProvincia",
                table: "Provincia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombrePais",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombreLocalidad",
                table: "Localidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaidProvincia",
                table: "Localidad",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaidProvincia",
                table: "Localidad",
                column: "ProvinciaidProvincia",
                principalTable: "Provincia",
                principalColumn: "idProvincia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
