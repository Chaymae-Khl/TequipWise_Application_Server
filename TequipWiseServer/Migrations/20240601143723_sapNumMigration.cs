using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class sapNumMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3299e978-5c19-45c7-b742-f27273d63c28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a350184-e926-497c-bb8f-ee241101576e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc2bbfa-814b-4f6d-9587-75922602ff23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b64acc34-7330-4b26-a81d-1d402b1e2d8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb3323d3-45cb-4cc2-bc79-85b12b239d73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f47c3cb5-a764-411d-9171-a5b583958e8d");

            migrationBuilder.AddColumn<string>(
                name: "SapNumber",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "242a214a-23f1-456e-92b1-42d732b44f33", "4", "HrManager", "HrManager" },
                    { "568ec0bb-b58b-46de-9038-a2b99444050a", "1", "Admin", "Admin" },
                    { "636902d7-636a-4ee8-bcc9-d24628e24ba8", "3", "DeptManager", "DeptManager" },
                    { "7940318f-a668-43a7-8d91-7dee61b0bfc0", "5", "FinanceManager", "ItAnalyst" },
                    { "937d4db6-73dd-40c9-91f8-246f4dc69565", "5", "FinanceManager", "FinanceManager" },
                    { "c37d6649-354e-460c-aa50-5f170055e58f", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242a214a-23f1-456e-92b1-42d732b44f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "568ec0bb-b58b-46de-9038-a2b99444050a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "636902d7-636a-4ee8-bcc9-d24628e24ba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7940318f-a668-43a7-8d91-7dee61b0bfc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "937d4db6-73dd-40c9-91f8-246f4dc69565");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37d6649-354e-460c-aa50-5f170055e58f");

            migrationBuilder.DropColumn(
                name: "SapNumber",
                table: "Plants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3299e978-5c19-45c7-b742-f27273d63c28", "3", "DeptManager", "DeptManager" },
                    { "4a350184-e926-497c-bb8f-ee241101576e", "5", "FinanceManager", "FinanceManager" },
                    { "acc2bbfa-814b-4f6d-9587-75922602ff23", "1", "Admin", "Admin" },
                    { "b64acc34-7330-4b26-a81d-1d402b1e2d8d", "5", "FinanceManager", "ItAnalyst" },
                    { "cb3323d3-45cb-4cc2-bc79-85b12b239d73", "2", "User", "User" },
                    { "f47c3cb5-a764-411d-9171-a5b583958e8d", "4", "HrManager", "HrManager" }
                });
        }
    }
}
