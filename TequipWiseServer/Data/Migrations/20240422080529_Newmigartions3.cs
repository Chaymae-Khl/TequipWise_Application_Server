using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Newmigartions3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463f94c3-a7f1-425a-a432-8cbc2444ae26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a94e2b49-005d-477c-9f69-50d9300a5dec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2861abb9-c4af-4364-b37e-3f1ee867d45e", "2", "User", "User" },
                    { "290b3512-87cf-42ce-9faa-65f25f537d87", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2861abb9-c4af-4364-b37e-3f1ee867d45e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "290b3512-87cf-42ce-9faa-65f25f537d87");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "463f94c3-a7f1-425a-a432-8cbc2444ae26", "2", "User", "User" },
                    { "a94e2b49-005d-477c-9f69-50d9300a5dec", "1", "Admin", "Admin" }
                });
        }
    }
}
