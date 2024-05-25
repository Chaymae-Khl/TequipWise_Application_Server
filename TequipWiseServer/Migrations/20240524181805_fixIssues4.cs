using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixIssues4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationId1",
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

            migrationBuilder.RenameColumn(
                name: "LocationId1",
                table: "AspNetUsers",
                newName: "locaId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_LocationId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_locaId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "224001a7-0870-438a-8b07-167e147de9dd", "5", "FinanceManager", "FinanceManager" },
                    { "2c4e6110-23a0-4f71-b361-43fe289d7d67", "1", "Admin", "Admin" },
                    { "7aab0921-c208-469d-ac78-6109cd8b66f3", "5", "FinanceManager", "ItAnalyst" },
                    { "9acdb56a-5315-4a3c-8656-e34c0ddbca91", "2", "User", "User" },
                    { "b202889f-638f-4716-8bb1-3c9b40a778c5", "3", "DeptManager", "DeptManager" },
                    { "bd93716d-5791-476f-92b1-2d1ee2c076e3", "4", "HrManager", "HrManager" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_locaId",
                table: "AspNetUsers",
                column: "locaId",
                principalTable: "Location",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_locaId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224001a7-0870-438a-8b07-167e147de9dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c4e6110-23a0-4f71-b361-43fe289d7d67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aab0921-c208-469d-ac78-6109cd8b66f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9acdb56a-5315-4a3c-8656-e34c0ddbca91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b202889f-638f-4716-8bb1-3c9b40a778c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd93716d-5791-476f-92b1-2d1ee2c076e3");

            migrationBuilder.RenameColumn(
                name: "locaId",
                table: "AspNetUsers",
                newName: "LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_locaId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_LocationId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationId1",
                table: "AspNetUsers",
                column: "LocationId1",
                principalTable: "Location",
                principalColumn: "LocationId");
        }
    }
}
