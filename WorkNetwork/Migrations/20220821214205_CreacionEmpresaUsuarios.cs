using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class CreacionEmpresaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Localidad_LocalidadID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Rubro_RubroID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaID",
                table: "Localidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localidad_LocalidadID",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincia_Pais_PaisID",
                table: "Provincia");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmpresaUsuarios",
                columns: table => new
                {
                    EmpresaUsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaUsuarios", x => x.EmpresaUsuarioID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48223681-7a4d-4c85-8e50-fa2aace41083", "b4e40bc3-4fe0-4bbe-ba6f-380917ee1fce", "Usuario", "USUARIO" },
                    { "a678a8fe-e381-47ed-bbbf-9c29d6175a66", "ff56e097-8321-463c-9382-726910c884a0", "SuperUsuario", "SUPERUSUARIO" },
                    { "bb4021b1-b66c-4083-8a70-42d766a69204", "b5bef62f-4c86-4512-8248-cf999c3bb315", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21833b5b-632b-4063-9527-c3ad7e775ee3", 0, "ef9b8de4-1035-491b-8a8d-7bd5ea9b148c", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEAclPne4jqLqTjbhwjiVPLKFU4l2pZq2Jle3nOSVSZ1YqcS07N2ihKFFGZ0sziHANA==", null, false, "349aa605-0cc6-4971-bf8c-36d5f0e7f567", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a678a8fe-e381-47ed-bbbf-9c29d6175a66", "21833b5b-632b-4063-9527-c3ad7e775ee3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Localidad_LocalidadID",
                table: "Empresa",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Rubro_RubroID",
                table: "Empresa",
                column: "RubroID",
                principalTable: "Rubro",
                principalColumn: "RubroID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaID",
                table: "Localidad",
                column: "ProvinciaID",
                principalTable: "Provincia",
                principalColumn: "ProvinciaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Localidad_LocalidadID",
                table: "Persona",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincia_Pais_PaisID",
                table: "Provincia",
                column: "PaisID",
                principalTable: "Pais",
                principalColumn: "PaisID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Localidad_LocalidadID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Rubro_RubroID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaID",
                table: "Localidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localidad_LocalidadID",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincia_Pais_PaisID",
                table: "Provincia");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante");

            migrationBuilder.DropTable(
                name: "EmpresaUsuarios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48223681-7a4d-4c85-8e50-fa2aace41083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb4021b1-b66c-4083-8a70-42d766a69204");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a678a8fe-e381-47ed-bbbf-9c29d6175a66", "21833b5b-632b-4063-9527-c3ad7e775ee3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a678a8fe-e381-47ed-bbbf-9c29d6175a66");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21833b5b-632b-4063-9527-c3ad7e775ee3");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Localidad_LocalidadID",
                table: "Empresa",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Rubro_RubroID",
                table: "Empresa",
                column: "RubroID",
                principalTable: "Rubro",
                principalColumn: "RubroID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaID",
                table: "Localidad",
                column: "ProvinciaID",
                principalTable: "Provincia",
                principalColumn: "ProvinciaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Localidad_LocalidadID",
                table: "Persona",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincia_Pais_PaisID",
                table: "Provincia",
                column: "PaisID",
                principalTable: "Pais",
                principalColumn: "PaisID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
