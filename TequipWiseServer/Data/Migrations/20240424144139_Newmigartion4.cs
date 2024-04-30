using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Newmigartion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9ac7cc-bea6-4ad6-b119-6214d54e3bf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7958a45-6d49-48ae-ae50-533dd8eecf11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80e1b360-c298-4b33-82b7-a153ed0e6ea4", "2", "User", "User" },
                    { "84773abb-19b4-4de4-80d1-04d4995d3f11", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e1b360-c298-4b33-82b7-a153ed0e6ea4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84773abb-19b4-4de4-80d1-04d4995d3f11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba9ac7cc-bea6-4ad6-b119-6214d54e3bf7", "1", "Admin", "Admin" },
                    { "e7958a45-6d49-48ae-ae50-533dd8eecf11", "2", "User", "User" }
                });
        }
    }
}
