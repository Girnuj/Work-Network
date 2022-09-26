using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class RolesUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "21833b5b-632b-4063-9527-c3ad7e775ee3", 0, "ef9b8de4-1035-491b-8a8d-7bd5ea9b148c", "ApplicationUser", "@gmail.com", false, false, null, "@GMAIL.COM", "@GMAIL.COM", "AQAAAAEAACcQAAAAEAclPne4jqLqTjbhwjiVPLKFU4l2pZq2Jle3nOSVSZ1YqcS07N2ihKFFGZ0sziHANA==", null, false, "349aa605-0cc6-4971-bf8c-36d5f0e7f567", false, "@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a678a8fe-e381-47ed-bbbf-9c29d6175a66", "21833b5b-632b-4063-9527-c3ad7e775ee3" });
        }
    }
}
