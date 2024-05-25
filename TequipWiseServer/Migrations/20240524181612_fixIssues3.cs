using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixIssues3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "LocationId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "069c8dfb-ca68-4995-aae2-07fec76cad6c", "4", "HrManager", "HrManager" },
                    { "31720444-3864-4344-aba3-45a2b4088cd3", "3", "DeptManager", "DeptManager" },
                    { "4e32833d-cf76-48c5-b98e-b6c7f4366c37", "5", "FinanceManager", "FinanceManager" },
                    { "4e88c36b-e27f-43f2-8cec-05d0c23ff150", "5", "FinanceManager", "ItAnalyst" },
                    { "94953416-519c-484d-8617-49381bd1cc59", "1", "Admin", "Admin" },
                    { "ba2f34d0-3919-4b06-84f9-2ddd991482b4", "2", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId1",
                table: "AspNetUsers",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationId1",
                table: "AspNetUsers",
                column: "LocationId1",
                principalTable: "Location",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId1",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069c8dfb-ca68-4995-aae2-07fec76cad6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31720444-3864-4344-aba3-45a2b4088cd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e32833d-cf76-48c5-b98e-b6c7f4366c37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e88c36b-e27f-43f2-8cec-05d0c23ff150");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94953416-519c-484d-8617-49381bd1cc59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba2f34d0-3919-4b06-84f9-2ddd991482b4");

            migrationBuilder.DropColumn(
                name: "LocationId1",
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
    }
}
