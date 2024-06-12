using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class roleManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "105f1176-9f4e-4d0c-b1bd-4cc8fecc764e", "6", "ItAnalyst", "ItAnalyst" },
                    { "12b929cb-624e-4d4f-85b1-19ee17cd6bd9", "5", "FinanceManager", "FinanceManager" },
                    { "239bb2a0-5931-4acf-aab4-1b9d2112f447", "3", "DeptManager", "DeptManager" },
                    { "71509eb4-a9fc-4b75-9f11-a9895d6d4237", "8", "Manager", "Manager" },
                    { "7cacd04d-260c-4039-801f-3ff5201d821b", "2", "User", "User" },
                    { "ac1dccb6-6910-42bf-8d78-16c6e336ac1c", "4", "HrManager", "HrManager" },
                    { "b0c4e15d-3328-4d99-87ea-4fbe2a1b2f41", "1", "Admin", "Admin" },
                    { "f668c43c-372a-4d11-8040-2a8aa6c2014d", "7", "Controller", "Controller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "105f1176-9f4e-4d0c-b1bd-4cc8fecc764e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12b929cb-624e-4d4f-85b1-19ee17cd6bd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239bb2a0-5931-4acf-aab4-1b9d2112f447");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71509eb4-a9fc-4b75-9f11-a9895d6d4237");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cacd04d-260c-4039-801f-3ff5201d821b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac1dccb6-6910-42bf-8d78-16c6e336ac1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0c4e15d-3328-4d99-87ea-4fbe2a1b2f41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f668c43c-372a-4d11-8040-2a8aa6c2014d");

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
    }
}
