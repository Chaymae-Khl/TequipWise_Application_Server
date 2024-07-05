using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class addManagerEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "EmailManger",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23201a6a-a047-40ed-9b32-4788c684e564", "1", "Admin", "Admin" },
                    { "866407e9-e332-4b1f-9ec9-104596596897", "5", "Controller", "Controller" },
                    { "9a5e0f8a-0776-407a-baf5-6c710c623a40", "2", "User", "User" },
                    { "bcc7a254-59b4-4db1-8e63-39e95ecd1355", "3", "Manager", "Manager" },
                    { "d1707d9f-75fb-40e9-bebb-84b208e9f72f", "4", "It Approver", "It Approver" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23201a6a-a047-40ed-9b32-4788c684e564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "866407e9-e332-4b1f-9ec9-104596596897");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a5e0f8a-0776-407a-baf5-6c710c623a40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcc7a254-59b4-4db1-8e63-39e95ecd1355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1707d9f-75fb-40e9-bebb-84b208e9f72f");

            migrationBuilder.DropColumn(
                name: "EmailManger",
                table: "Departments");

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
    }
}
