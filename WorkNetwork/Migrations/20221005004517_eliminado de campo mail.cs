using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class eliminadodecampomail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Email",
                table: "Empresa");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono2",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono1",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono2",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono1",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8fde269a-5785-4ee5-8ed4-064d6bdaf60b", "9b6b2559-78ff-46f6-a590-7441f2f36e80", "SuperUsuario", "SUPERUSUARIO" },
                    { "c771e64e-a1d9-4582-8b41-beab13ce34a4", "bc8e8054-d00e-4f50-a2cd-b1766432751a", "Usuario", "USUARIO" },
                    { "d2867f37-8093-4da9-afee-aeaaad75e79f", "d686d38d-8bec-4963-a9c0-ef98901e4540", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d231de0-4824-4968-b877-3a12df042f05", 0, "d3c7295c-34ef-4d59-8fd9-c23f150cbaf2", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEH8aStDyvnis6yuDrrEd7T1KoleGr9+TKNi7vqMFMbRNc3+ZeN2ywb+pBsesPN2/Tg==", null, false, "336ac75a-7bbe-4ab0-9e98-0bbc4d7cc9ef", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8fde269a-5785-4ee5-8ed4-064d6bdaf60b", "2d231de0-4824-4968-b877-3a12df042f05" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c771e64e-a1d9-4582-8b41-beab13ce34a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2867f37-8093-4da9-afee-aeaaad75e79f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fde269a-5785-4ee5-8ed4-064d6bdaf60b", "2d231de0-4824-4968-b877-3a12df042f05" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fde269a-5785-4ee5-8ed4-064d6bdaf60b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d231de0-4824-4968-b877-3a12df042f05");

            migrationBuilder.AlterColumn<int>(
                name: "Telefono2",
                table: "Persona",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Telefono1",
                table: "Persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Telefono2",
                table: "Empresa",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Telefono1",
                table: "Empresa",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
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
    }
}
