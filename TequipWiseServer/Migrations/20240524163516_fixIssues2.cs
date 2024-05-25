using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixIssues2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Plants_PlantNumber",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlantNumber",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f92fe61-81f6-4ec5-9ec8-14c11fdd7f0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "906a3ae1-f93c-4aad-becf-6ad3b5b4d271");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1b9f80b-60d5-4d7d-8d57-1c9fc5fc0942");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4a57cb5-982b-4a2d-814b-e5e43e9cbfa1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c568ffab-1059-47c5-9993-f07d53ab4070");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6789403-f064-43e1-8e9b-2e1ec718bf8a");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlantNumber",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10445a9b-3c33-4fa9-83a9-5d9b7e349b05", "2", "User", "User" },
                    { "14680205-25b7-44fb-919c-c93e85d44156", "1", "Admin", "Admin" },
                    { "41606d96-4415-4a59-bf68-9f8695e035b8", "5", "FinanceManager", "FinanceManager" },
                    { "6ed37d70-6435-4208-9e23-dea73473b198", "4", "HrManager", "HrManager" },
                    { "933c1b02-fe51-4ce1-8004-157b969f2317", "3", "DeptManager", "DeptManager" },
                    { "db25bb20-e3bc-4441-8769-9aa4edb4b878", "5", "FinanceManager", "ItAnalyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10445a9b-3c33-4fa9-83a9-5d9b7e349b05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14680205-25b7-44fb-919c-c93e85d44156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41606d96-4415-4a59-bf68-9f8695e035b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed37d70-6435-4208-9e23-dea73473b198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "933c1b02-fe51-4ce1-8004-157b969f2317");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db25bb20-e3bc-4441-8769-9aa4edb4b878");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f92fe61-81f6-4ec5-9ec8-14c11fdd7f0b", "1", "Admin", "Admin" },
                    { "906a3ae1-f93c-4aad-becf-6ad3b5b4d271", "4", "HrManager", "HrManager" },
                    { "b1b9f80b-60d5-4d7d-8d57-1c9fc5fc0942", "3", "DeptManager", "DeptManager" },
                    { "b4a57cb5-982b-4a2d-814b-e5e43e9cbfa1", "5", "FinanceManager", "FinanceManager" },
                    { "c568ffab-1059-47c5-9993-f07d53ab4070", "2", "User", "User" },
                    { "c6789403-f064-43e1-8e9b-2e1ec718bf8a", "5", "FinanceManager", "ItAnalyst" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlantNumber",
                table: "AspNetUsers",
                column: "PlantNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Plants_PlantNumber",
                table: "AspNetUsers",
                column: "PlantNumber",
                principalTable: "Plants",
                principalColumn: "PlantNumber");
        }
    }
}
