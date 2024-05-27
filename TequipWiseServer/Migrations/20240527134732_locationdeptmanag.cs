using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class locationdeptmanag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "223f1665-8722-4242-a67f-86751efee067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "765e92ab-3fae-45c1-99f7-8b168661a103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8197a5b-eb3e-4105-b4a6-1da9015fb47e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba5a2412-7e7a-468e-ac41-df379327c620");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4cc29f7-6c6b-4522-b981-42a48257f7ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc2c06eb-871b-41cc-8783-a168a7116f95");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "LocationDepartments",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_LocationDepartments_ManagerId",
                table: "LocationDepartments",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationDepartments_AspNetUsers_ManagerId",
                table: "LocationDepartments",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationDepartments_AspNetUsers_ManagerId",
                table: "LocationDepartments");

            migrationBuilder.DropIndex(
                name: "IX_LocationDepartments_ManagerId",
                table: "LocationDepartments");

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

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "LocationDepartments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "223f1665-8722-4242-a67f-86751efee067", "2", "User", "User" },
                    { "765e92ab-3fae-45c1-99f7-8b168661a103", "5", "FinanceManager", "FinanceManager" },
                    { "a8197a5b-eb3e-4105-b4a6-1da9015fb47e", "1", "Admin", "Admin" },
                    { "ba5a2412-7e7a-468e-ac41-df379327c620", "4", "HrManager", "HrManager" },
                    { "c4cc29f7-6c6b-4522-b981-42a48257f7ac", "3", "DeptManager", "DeptManager" },
                    { "fc2c06eb-871b-41cc-8783-a168a7116f95", "5", "FinanceManager", "ItAnalyst" }
                });
        }
    }
}
