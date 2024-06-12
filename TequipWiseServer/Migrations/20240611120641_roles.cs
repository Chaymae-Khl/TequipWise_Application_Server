using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "038590b7-52bf-47d0-ab08-5fa122ee3ea4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c9aac28-2d32-4cf8-b0bd-a0b6d5a38963");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c8ac29-821a-47ab-8ae3-a695777a518b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33c6f827-8fb2-4cda-b861-05621f3f6a90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e28afea-d263-48ba-bf38-42f736bc2869");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9573da3c-6a18-4f1e-83e6-f0a975bcbfa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef059a7b-19d1-4e9a-96d3-63fc7a5fb085");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06bf94fd-a9aa-43c7-a13d-2cda35143c54", "5", "FinanceManager", "FinanceManager" },
                    { "3a36a8c0-2867-4f03-96d3-336cb06138f1", "6", "ItAnalyst", "ItAnalyst" },
                    { "65b312c5-487c-4cdf-8ba4-6f85696d82c5", "7", "Controller", "Controller" },
                    { "673ee1bc-8d4a-47a4-a889-3627b5669d3b", "3", "DeptManager", "DeptManager" },
                    { "856e1132-f3f8-42ce-9b05-609941f67f83", "1", "Admin", "Admin" },
                    { "90902e74-b4cb-4ebd-a2ba-ebf5417c8b5d", "4", "HrManager", "HrManager" },
                    { "bd4c85b9-2c1d-4d94-9434-a63967917b40", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06bf94fd-a9aa-43c7-a13d-2cda35143c54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a36a8c0-2867-4f03-96d3-336cb06138f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65b312c5-487c-4cdf-8ba4-6f85696d82c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "673ee1bc-8d4a-47a4-a889-3627b5669d3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "856e1132-f3f8-42ce-9b05-609941f67f83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90902e74-b4cb-4ebd-a2ba-ebf5417c8b5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd4c85b9-2c1d-4d94-9434-a63967917b40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "038590b7-52bf-47d0-ab08-5fa122ee3ea4", "2", "User", "User" },
                    { "0c9aac28-2d32-4cf8-b0bd-a0b6d5a38963", "1", "Admin", "Admin" },
                    { "32c8ac29-821a-47ab-8ae3-a695777a518b", "3", "DeptManager", "DeptManager" },
                    { "33c6f827-8fb2-4cda-b861-05621f3f6a90", "5", "FinanceManager", "FinanceManager" },
                    { "4e28afea-d263-48ba-bf38-42f736bc2869", "7", "Controller", "Controller" },
                    { "9573da3c-6a18-4f1e-83e6-f0a975bcbfa3", "6", "ItAnalyst", "ItAnalyst" },
                    { "ef059a7b-19d1-4e9a-96d3-63fc7a5fb085", "4", "HrManager", "HrManager" }
                });
        }
    }
}
