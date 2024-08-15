using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wandermate.backened.Migrations
{
    /// <inheritdoc />
    public partial class auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4614aa79-1594-4e23-b510-b1cf8b41f173");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49443fb-1c46-451e-bae9-74c88439da77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae1efc2c-de44-46bd-8722-70323f17c8e3", null, "User", "USER" },
                    { "e2abae1d-8f4d-4b1b-b4dc-c34d03c42763", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae1efc2c-de44-46bd-8722-70323f17c8e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2abae1d-8f4d-4b1b-b4dc-c34d03c42763");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4614aa79-1594-4e23-b510-b1cf8b41f173", null, "Admin", "ADMIN" },
                    { "d49443fb-1c46-451e-bae9-74c88439da77", null, "User", "USER" }
                });
        }
    }
}
