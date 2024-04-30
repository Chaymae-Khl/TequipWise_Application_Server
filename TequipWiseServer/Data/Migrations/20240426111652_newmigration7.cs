using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04dff94a-01f1-4b7a-bb3f-7a455246e740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fadadf-2f60-4ac9-b7a4-0f708e38a4ba");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Responsibility",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5821ae5a-61f0-49ca-be5c-5bbfd2efe33e", "2", "User", "User" },
                    { "7cfb7a96-3c16-4d3c-8f20-bceb1f4fd9e5", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5821ae5a-61f0-49ca-be5c-5bbfd2efe33e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfb7a96-3c16-4d3c-8f20-bceb1f4fd9e5");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsibility",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04dff94a-01f1-4b7a-bb3f-7a455246e740", "1", "Admin", "Admin" },
                    { "c0fadadf-2f60-4ac9-b7a4-0f708e38a4ba", "2", "User", "User" }
                });
        }
    }
}
