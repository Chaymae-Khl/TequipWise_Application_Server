using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7decf03f-29c5-4ef8-9d4c-1265e5a478ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9320699e-6173-4552-8eb3-192d034ac591");

            migrationBuilder.AddColumn<string>(
                name: "plant_name",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a3a833b-2526-467d-b604-69f741781028", "1", "Admin", "Admin" },
                    { "cdbb2ece-df87-4e9e-ba1c-db899a29e44d", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a3a833b-2526-467d-b604-69f741781028");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdbb2ece-df87-4e9e-ba1c-db899a29e44d");

            migrationBuilder.DropColumn(
                name: "plant_name",
                table: "Plants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7decf03f-29c5-4ef8-9d4c-1265e5a478ec", "2", "User", "User" },
                    { "9320699e-6173-4552-8eb3-192d034ac591", "1", "Admin", "Admin" }
                });
        }
    }
}
