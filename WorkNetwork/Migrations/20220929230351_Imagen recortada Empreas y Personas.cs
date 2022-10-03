using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class ImagenrecortadaEmpreasyPersonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ImagenRecortada",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoImagen",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenRecortada",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoImagen",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b145736-d10a-4f23-b84e-41dfe1894c3e", "153e618a-0583-4e6b-be8c-524217723eaf", "Empresa", "EMPRESA" },
                    { "82d64a6e-d268-44ba-8807-8de2d7e46444", "c43d0dff-cc43-456c-bdb1-80d8da3a2231", "SuperUsuario", "SUPERUSUARIO" },
                    { "fdb327e3-6003-4b02-be1d-1f76364fc034", "cdc31875-a79c-402c-a503-23fbe622a20d", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25afea56-b7e4-47eb-9c30-a45fd1aa4b4e", 0, "850f8cd3-8ea2-4536-8ccf-1037b7ff9f6b", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEAhqDgpgp1eX8PsFTmObStfQ7LrVrdr0PR+7+mKiGDqRGXG1ooQuynnhIu3kMsJJ7Q==", null, false, "32bd9af8-1d75-4de5-8cf9-da4d1c7bb2ee", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "82d64a6e-d268-44ba-8807-8de2d7e46444", "25afea56-b7e4-47eb-9c30-a45fd1aa4b4e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b145736-d10a-4f23-b84e-41dfe1894c3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdb327e3-6003-4b02-be1d-1f76364fc034");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82d64a6e-d268-44ba-8807-8de2d7e46444", "25afea56-b7e4-47eb-9c30-a45fd1aa4b4e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d64a6e-d268-44ba-8807-8de2d7e46444");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25afea56-b7e4-47eb-9c30-a45fd1aa4b4e");

            migrationBuilder.DropColumn(
                name: "ImagenRecortada",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "TipoImagen",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ImagenRecortada",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "TipoImagen",
                table: "Empresa");

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
    }
}
