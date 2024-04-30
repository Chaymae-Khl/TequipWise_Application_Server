using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "04dff94a-01f1-4b7a-bb3f-7a455246e740", "1", "Admin", "Admin" },
                    { "c0fadadf-2f60-4ac9-b7a4-0f708e38a4ba", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04dff94a-01f1-4b7a-bb3f-7a455246e740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fadadf-2f60-4ac9-b7a4-0f708e38a4ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80e1b360-c298-4b33-82b7-a153ed0e6ea4", "2", "User", "User" },
                    { "84773abb-19b4-4de4-80d1-04d4995d3f11", "1", "Admin", "Admin" }
                });
        }
    }
}
