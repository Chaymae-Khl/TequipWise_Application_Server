using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class managRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05b6f7b1-0a80-4f81-92fe-4c479c8db698");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1302322e-bb1c-4498-a286-a62c8ba5d690");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1703c713-0943-45db-8078-2a371c17a0f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e5d24a1-353b-44b4-a742-6edb25a51cf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "569166de-c1e6-4f33-a968-257dfdbf9236");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66fd005c-a99e-4ac8-963b-6e6fad44b1fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee5fcb3a-4513-40a7-85fd-92ae2bc36ad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f42a12ba-dc78-4547-8a3b-c1b3b13fe910");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38795a32-a6fc-4dad-9d4d-fbb9d352bca5", "1", "Admin", "Admin" },
                    { "65fdfa17-8a7b-4ebd-8a7b-c4fadca2a1b3", "3", "DeptManager", "DeptManager" },
                    { "97e5aed1-86dc-4356-8b6c-a175ec958dbf", "4", "ItAnalyst", "ItAnalyst" },
                    { "9eb14dec-3d7b-4486-9cd3-1d7363b58ab1", "2", "User", "User" },
                    { "e44cd447-16ae-4468-bb84-1d240dd6311b", "5", "Controller", "Controller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38795a32-a6fc-4dad-9d4d-fbb9d352bca5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65fdfa17-8a7b-4ebd-8a7b-c4fadca2a1b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97e5aed1-86dc-4356-8b6c-a175ec958dbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eb14dec-3d7b-4486-9cd3-1d7363b58ab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e44cd447-16ae-4468-bb84-1d240dd6311b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05b6f7b1-0a80-4f81-92fe-4c479c8db698", "1", "Admin", "Admin" },
                    { "1302322e-bb1c-4498-a286-a62c8ba5d690", "8", "Manager", "Manager" },
                    { "1703c713-0943-45db-8078-2a371c17a0f7", "4", "HrManager", "HrManager" },
                    { "4e5d24a1-353b-44b4-a742-6edb25a51cf4", "6", "ItAnalyst", "ItAnalyst" },
                    { "569166de-c1e6-4f33-a968-257dfdbf9236", "5", "FinanceManager", "FinanceManager" },
                    { "66fd005c-a99e-4ac8-963b-6e6fad44b1fc", "7", "Controller", "Controller" },
                    { "ee5fcb3a-4513-40a7-85fd-92ae2bc36ad9", "2", "User", "User" },
                    { "f42a12ba-dc78-4547-8a3b-c1b3b13fe910", "3", "DeptManager", "DeptManager" }
                });
        }
    }
}
