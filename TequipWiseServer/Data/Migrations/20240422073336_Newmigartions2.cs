using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Newmigartions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ffae98-be0a-4c1d-a64c-a9793d10623d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f0999ed-0366-4c84-8573-d41cefc00012");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "463f94c3-a7f1-425a-a432-8cbc2444ae26", "2", "User", "User" },
                    { "a94e2b49-005d-477c-9f69-50d9300a5dec", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463f94c3-a7f1-425a-a432-8cbc2444ae26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a94e2b49-005d-477c-9f69-50d9300a5dec");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20ffae98-be0a-4c1d-a64c-a9793d10623d", "2", "User", "User" },
                    { "7f0999ed-0366-4c84-8573-d41cefc00012", "1", "Admin", "Admin" }
                });
        }
    }
}
