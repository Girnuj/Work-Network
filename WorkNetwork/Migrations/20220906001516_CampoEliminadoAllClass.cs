using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class CampoEliminadoAllClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53805585-42e4-4a5b-b7bf-c1b948accb1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56db5222-895e-4098-9bbd-7af9f6e849b1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "24c8fb3a-21ae-4de4-9b5b-c08b05c8845e", "8f1c2406-aca3-446f-a1fb-16f112a5d106" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24c8fb3a-21ae-4de4-9b5b-c08b05c8845e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f1c2406-aca3-446f-a1fb-16f112a5d106");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Vacante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Provincia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Persona",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Localidad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Empresa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24c8fb3a-21ae-4de4-9b5b-c08b05c8845e", "01350a2b-c4dc-4417-8df5-0240a901552e", "SuperUsuario", "SUPERUSUARIO" },
                    { "53805585-42e4-4a5b-b7bf-c1b948accb1a", "0802d633-414e-405a-9e42-3c82e30552b0", "Empresa", "EMPRESA" },
                    { "56db5222-895e-4098-9bbd-7af9f6e849b1", "54454864-4014-43aa-8e12-6c3773c1b0ac", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f1c2406-aca3-446f-a1fb-16f112a5d106", 0, "0544c0ef-88b2-45cc-a623-02a421836013", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEJsPhw/j0646GID1P2kuber5FktgwvaA0gIPjkkacmgWXidirR97eYa9piwcTLjE5w==", null, false, "4b2e62c8-9992-4604-8367-25e4e62b5a81", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "24c8fb3a-21ae-4de4-9b5b-c08b05c8845e", "8f1c2406-aca3-446f-a1fb-16f112a5d106" });
        }
    }
}
