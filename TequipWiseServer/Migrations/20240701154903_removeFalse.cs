using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class removeFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01073f74-f057-4184-919b-bfd84c020d96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13898a98-0adc-413e-a59c-2833537d658c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d40aa2b-6355-479c-92f2-585b60552d94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b04e077-1ebd-40be-9ef5-669219d8f235");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "973734c1-05e8-4a23-bb75-fe02f572cc1e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a8a28f1-21b6-431b-aef8-2f6fb4e1638f", "4", "It Approver", "It Approver" },
                    { "12187402-719b-4b9c-b7ae-1fa42dfdff73", "2", "User", "User" },
                    { "27d29d75-a99d-4557-8918-e2c1fa8e53d4", "3", "Manager", "Manager" },
                    { "e15ed7a9-1683-42ae-9c0d-038f22677060", "1", "Admin", "Admin" },
                    { "fd88971f-a8ce-4e7d-b8fc-f452bce0b942", "5", "Controller", "Controller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a8a28f1-21b6-431b-aef8-2f6fb4e1638f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12187402-719b-4b9c-b7ae-1fa42dfdff73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d29d75-a99d-4557-8918-e2c1fa8e53d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15ed7a9-1683-42ae-9c0d-038f22677060");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd88971f-a8ce-4e7d-b8fc-f452bce0b942");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01073f74-f057-4184-919b-bfd84c020d96", "1", "Admin", "Admin" },
                    { "13898a98-0adc-413e-a59c-2833537d658c", "5", "Controller", "Controller" },
                    { "5d40aa2b-6355-479c-92f2-585b60552d94", "3", "Manager", "Manager" },
                    { "6b04e077-1ebd-40be-9ef5-669219d8f235", "2", "User", "User" },
                    { "973734c1-05e8-4a23-bb75-fe02f572cc1e", "4", "It Approver", "It Approver" }
                });
        }
    }
}
