using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class sapNumMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ab4a7ed-da8d-463a-9065-56a38645187c", "4", "HrManager", "HrManager" },
                    { "0f44201e-eeab-4923-bbdd-e893eaafba55", "3", "DeptManager", "DeptManager" },
                    { "12bde992-8663-4714-91c1-c5fdff77658e", "7", "Controller", "Controller" },
                    { "2387aeb7-eb3e-49fe-932c-bc5676ab5184", "5", "FinanceManager", "FinanceManager" },
                    { "a80e61cb-a815-417e-bfc8-ebd4e2ef5466", "1", "Admin", "Admin" },
                    { "bf8b9616-6b31-4404-bd37-983387da0d01", "2", "User", "User" },
                    { "ffcc4a52-ef46-42b6-a1a8-0a8989c85b16", "6", "ItAnalyst", "ItAnalyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ab4a7ed-da8d-463a-9065-56a38645187c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f44201e-eeab-4923-bbdd-e893eaafba55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12bde992-8663-4714-91c1-c5fdff77658e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2387aeb7-eb3e-49fe-932c-bc5676ab5184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a80e61cb-a815-417e-bfc8-ebd4e2ef5466");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf8b9616-6b31-4404-bd37-983387da0d01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffcc4a52-ef46-42b6-a1a8-0a8989c85b16");

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
    }
}
