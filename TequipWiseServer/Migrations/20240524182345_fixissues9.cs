using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixissues9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224001a7-0870-438a-8b07-167e147de9dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c4e6110-23a0-4f71-b361-43fe289d7d67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aab0921-c208-469d-ac78-6109cd8b66f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9acdb56a-5315-4a3c-8656-e34c0ddbca91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b202889f-638f-4716-8bb1-3c9b40a778c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd93716d-5791-476f-92b1-2d1ee2c076e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07706726-fd7b-44b8-9043-3ab28ac998f2", "3", "DeptManager", "DeptManager" },
                    { "1b33be02-fe61-474a-8680-148b0aeb22eb", "4", "HrManager", "HrManager" },
                    { "445da020-c12d-48f5-a614-3c911252cb2b", "5", "FinanceManager", "FinanceManager" },
                    { "44f9875c-3303-4134-8861-0eb4038b9a83", "2", "User", "User" },
                    { "6c42a723-6fe5-49a1-8199-7315a91fdbbf", "1", "Admin", "Admin" },
                    { "ed8a60e5-96d9-407a-a437-3e274c6ef353", "5", "FinanceManager", "ItAnalyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07706726-fd7b-44b8-9043-3ab28ac998f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b33be02-fe61-474a-8680-148b0aeb22eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "445da020-c12d-48f5-a614-3c911252cb2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44f9875c-3303-4134-8861-0eb4038b9a83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c42a723-6fe5-49a1-8199-7315a91fdbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed8a60e5-96d9-407a-a437-3e274c6ef353");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "224001a7-0870-438a-8b07-167e147de9dd", "5", "FinanceManager", "FinanceManager" },
                    { "2c4e6110-23a0-4f71-b361-43fe289d7d67", "1", "Admin", "Admin" },
                    { "7aab0921-c208-469d-ac78-6109cd8b66f3", "5", "FinanceManager", "ItAnalyst" },
                    { "9acdb56a-5315-4a3c-8656-e34c0ddbca91", "2", "User", "User" },
                    { "b202889f-638f-4716-8bb1-3c9b40a778c5", "3", "DeptManager", "DeptManager" },
                    { "bd93716d-5791-476f-92b1-2d1ee2c076e3", "4", "HrManager", "HrManager" }
                });
        }
    }
}
