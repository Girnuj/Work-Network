using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class ModeloPersonaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "302d2597-e124-4b42-b77e-3d4cd647377d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff0a8671-c0a3-4b16-92ee-f67cd148552c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3da07fd0-93c3-4fdf-96a1-417e5bdb04ef", "cc4deb1c-cce8-4228-9868-61e3323c7342" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da07fd0-93c3-4fdf-96a1-417e5bdb04ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc4deb1c-cce8-4228-9868-61e3323c7342");

            migrationBuilder.CreateTable(
                name: "PersonaUsuarios",
                columns: table => new
                {
                    PersonaUsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaUsuarios", x => x.PersonaUsuarioID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05ce26ee-dc2f-406d-aac3-adaea803bafc", "92858a3c-b817-4d01-8db2-e0960289c419", "Usuario", "USUARIO" },
                    { "6b0481b6-31e3-442e-b168-d9c044700c00", "c70d4066-d325-45e5-acb6-a8311e602dd7", "SuperUsuario", "SUPERUSUARIO" },
                    { "85997de6-8ab7-46f7-b6d0-0751e9cce1ba", "f1b297f8-41d9-438b-9d2e-09cec64df1a3", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "adf8a72b-f2ba-40c3-b69b-da1aaedde99c", 0, "2b895e09-7392-435f-9582-af56dd66c9c6", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEAE3T9so9UNG4cEtuD0XWMhR4vvuXI316puJPi8xmRFkjMOGMAKONjKYWICJmFeAsQ==", null, false, "60599654-07a5-44b9-aa57-0e8f882685de", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6b0481b6-31e3-442e-b168-d9c044700c00", "adf8a72b-f2ba-40c3-b69b-da1aaedde99c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaUsuarios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05ce26ee-dc2f-406d-aac3-adaea803bafc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85997de6-8ab7-46f7-b6d0-0751e9cce1ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6b0481b6-31e3-442e-b168-d9c044700c00", "adf8a72b-f2ba-40c3-b69b-da1aaedde99c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0481b6-31e3-442e-b168-d9c044700c00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf8a72b-f2ba-40c3-b69b-da1aaedde99c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "302d2597-e124-4b42-b77e-3d4cd647377d", "b06110b6-fdc9-460e-b63e-a3775a54b1d5", "Empresa", "EMPRESA" },
                    { "3da07fd0-93c3-4fdf-96a1-417e5bdb04ef", "3fec8c8d-6695-4980-a313-69ba90a10ff1", "SuperUsuario", "SUPERUSUARIO" },
                    { "ff0a8671-c0a3-4b16-92ee-f67cd148552c", "c49b0650-f1eb-49aa-ad4b-b7eb45437dd7", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cc4deb1c-cce8-4228-9868-61e3323c7342", 0, "c85f3478-499d-41c7-9d89-27c48f8113d5", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEIydR87srHOz04hUwULTweEsW350cKJPFN3zvud+ANGDI3ZXwikf6Q8C7OkqE44JPw==", null, false, "9b14b262-f0cf-4f66-bd29-cea47d58c0fa", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3da07fd0-93c3-4fdf-96a1-417e5bdb04ef", "cc4deb1c-cce8-4228-9868-61e3323c7342" });
        }
    }
}
