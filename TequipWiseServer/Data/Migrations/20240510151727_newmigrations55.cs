using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigrations55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a47b55c-c91f-4dab-8f7e-bfd1002f8d72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90bc3d23-43d5-42bc-bc53-e4937b3964ee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a66fcacd-769c-4df8-a70d-dca7da17346b", "1", "Admin", "Admin" },
                    { "dfe000f3-5821-47c3-9a60-891e2a90f794", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66fcacd-769c-4df8-a70d-dca7da17346b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe000f3-5821-47c3-9a60-891e2a90f794");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a47b55c-c91f-4dab-8f7e-bfd1002f8d72", "2", "User", "User" },
                    { "90bc3d23-43d5-42bc-bc53-e4937b3964ee", "1", "Admin", "Admin" }
                });
        }
    }
}
