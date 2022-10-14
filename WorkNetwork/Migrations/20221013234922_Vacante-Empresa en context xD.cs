using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class VacanteEmpresaencontextxD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "VacanteEmpresas",
                columns: table => new
                {
                    VacanteEmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacanteID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacanteEmpresas", x => x.VacanteEmpresaId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3380b1f9-07df-401f-93a3-4e30701816bd", "a4187714-f350-40aa-a6e9-40216da05548", "SuperUsuario", "SUPERUSUARIO" },
                    { "8373f26b-34da-4a06-a658-5f4dfd2fbaba", "ac08c022-0235-49f5-9f21-d74482d78bb9", "Usuario", "USUARIO" },
                    { "b22909f5-c51b-4fe6-9e48-e3cb632c09a7", "9d993b3d-78f1-4e02-98df-616235eee5f2", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b", 0, "6d3ff0a5-5c27-44fe-95c2-7270a0161d13", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEHL47gMg/YhBYnrXoACEK4kKqrt33zV/52h89T8gk97Q3HdwXRJRDkwWiuqpaje3dw==", null, false, "f68f8548-1d8f-443b-9451-387dde865078", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3380b1f9-07df-401f-93a3-4e30701816bd", "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacanteEmpresas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8373f26b-34da-4a06-a658-5f4dfd2fbaba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22909f5-c51b-4fe6-9e48-e3cb632c09a7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3380b1f9-07df-401f-93a3-4e30701816bd", "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3380b1f9-07df-401f-93a3-4e30701816bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b");

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
        }
    }
}
