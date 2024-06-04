using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class removebuildingField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Location");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "079fab96-630a-43dd-82e5-7fb391359ad8", "6", "ItAnalyst", "ItAnalyst" },
                    { "24874f6d-5668-466c-9685-9ce1f2be1661", "3", "DeptManager", "DeptManager" },
                    { "4eb6938c-81bb-4b87-967e-58d8ccf4cb27", "4", "HrManager", "HrManager" },
                    { "aa8fa98b-f3e3-453e-88cc-98d74f367948", "1", "Admin", "Admin" },
                    { "b603a1bf-6892-494e-a7fa-bdc0b368ef87", "5", "FinanceManager", "FinanceManager" },
                    { "dfc55ae9-02be-4c46-a3e3-a00155645b56", "2", "User", "User" },
                    { "f5b69d67-98bf-4ec2-829d-e9e35af882e5", "7", "Controller", "Controller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "079fab96-630a-43dd-82e5-7fb391359ad8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24874f6d-5668-466c-9685-9ce1f2be1661");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6938c-81bb-4b87-967e-58d8ccf4cb27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa8fa98b-f3e3-453e-88cc-98d74f367948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b603a1bf-6892-494e-a7fa-bdc0b368ef87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfc55ae9-02be-4c46-a3e3-a00155645b56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b69d67-98bf-4ec2-829d-e9e35af882e5");

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
