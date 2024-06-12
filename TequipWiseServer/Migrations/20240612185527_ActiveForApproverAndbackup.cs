using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class ActiveForApproverAndbackup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "ApproverActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "backupActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ApproverActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "backupActive",
                table: "AspNetUsers");

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
    }
}
