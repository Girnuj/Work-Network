using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class VacanteEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d7429d1-5b11-4694-bc49-1a8d47e3c29d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eaa0818-929f-4432-b7c3-95a2532bff70");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "52821745-f641-4920-94c2-9f8212358547", "066c546a-3d13-4f48-81e1-6a2deb3c1709" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52821745-f641-4920-94c2-9f8212358547");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "066c546a-3d13-4f48-81e1-6a2deb3c1709");

            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "PersonaVacante");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagen",
                table: "Vacante",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaID",
                table: "Vacante",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RubroID",
                table: "Vacante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoImagen",
                table: "Vacante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionDePersona",
                table: "PersonaVacante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSolicitud",
                table: "PersonaVacante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a81805c-c9c0-479e-85a1-1b1fc7d93a35", "80af536a-c300-4928-b99a-4e5b725656fa", "Empresa", "EMPRESA" },
                    { "b1f61120-73ea-4955-afa5-68452e8a384b", "99648d74-6c8c-42e8-b5e2-bcaaf3891867", "Usuario", "USUARIO" },
                    { "f7dbac72-800e-430e-8212-2ac862413c77", "2f49f318-ad9e-4382-aaa4-caae57d8b743", "SuperUsuario", "SUPERUSUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c813d0d8-e0da-42b2-a79b-c11bffe4a20b", 0, "04a773b0-b198-4469-baf5-fed720373385", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEJcISW1z4i9CXivFT0o2Hr25BuoMBKPexAuX96345eZiuIgUItY7u0tfDnqzXiNLUA==", null, false, "32adea4b-57f3-4e81-9d7d-885a48c9c44f", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f7dbac72-800e-430e-8212-2ac862413c77", "c813d0d8-e0da-42b2-a79b-c11bffe4a20b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a81805c-c9c0-479e-85a1-1b1fc7d93a35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1f61120-73ea-4955-afa5-68452e8a384b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7dbac72-800e-430e-8212-2ac862413c77", "c813d0d8-e0da-42b2-a79b-c11bffe4a20b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7dbac72-800e-430e-8212-2ac862413c77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c813d0d8-e0da-42b2-a79b-c11bffe4a20b");

            migrationBuilder.DropColumn(
                name: "RubroID",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "TipoImagen",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "DescripcionDePersona",
                table: "PersonaVacante");

            migrationBuilder.DropColumn(
                name: "FechaSolicitud",
                table: "PersonaVacante");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagen",
                table: "Vacante",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaID",
                table: "Vacante",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaID",
                table: "PersonaVacante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d7429d1-5b11-4694-bc49-1a8d47e3c29d", "24e6d719-1f58-4b6a-a159-2e1b2cb64144", "Usuario", "USUARIO" },
                    { "4eaa0818-929f-4432-b7c3-95a2532bff70", "babad172-6283-46fc-92b7-06a25bba10ef", "Empresa", "EMPRESA" },
                    { "52821745-f641-4920-94c2-9f8212358547", "df684d5e-7250-49d2-8a40-630569fc03ab", "SuperUsuario", "SUPERUSUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "066c546a-3d13-4f48-81e1-6a2deb3c1709", 0, "9f40df03-9c50-4bc4-949f-93faeb16de2b", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEL/5RYyxvZ25BWsP2lgHI3u98I8UNDMa13rNkXNtYFUBDA4aDK+NYLAMfWavZfdR9w==", null, false, "5170bed4-fd10-44e7-a9ec-1674f0f4240b", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "52821745-f641-4920-94c2-9f8212358547", "066c546a-3d13-4f48-81e1-6a2deb3c1709" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vacante_Empresa_EmpresaID",
                table: "Vacante",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
