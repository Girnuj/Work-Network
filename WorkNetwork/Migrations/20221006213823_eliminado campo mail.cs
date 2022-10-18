using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class eliminadocampomail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Persona");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
