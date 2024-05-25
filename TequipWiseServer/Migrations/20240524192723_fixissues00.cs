using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixissues00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02cff984-d02a-456f-9817-a4ff4e2e650e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8138017f-5f37-49f5-b620-371858f0e270");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b9cbca-1c7a-44e9-934b-8af9489e3820");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d84da186-e92e-4236-a62d-ffef863d653a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef0fd9e2-466e-4574-9daf-31bbee47dcb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec994ff-0760-44da-8280-7ad08bcf3d16");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "plantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88782a18-18df-402f-82ae-da7bde0441e5", "2", "User", "User" },
                    { "8fb511cc-3eb3-4bc4-a8e6-904c1a2def61", "3", "DeptManager", "DeptManager" },
                    { "9dc85cd5-4266-4b18-b671-f467b7547460", "1", "Admin", "Admin" },
                    { "aedd3195-3521-417f-92e2-2b90205d3483", "5", "FinanceManager", "FinanceManager" },
                    { "b3bd7993-5c99-43cc-8ced-843bf00f09de", "4", "HrManager", "HrManager" },
                    { "c54f6a89-2768-444d-b523-b50c6b8c8a1f", "5", "FinanceManager", "ItAnalyst" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_plantId",
                table: "AspNetUsers",
                column: "plantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Plants_plantId",
                table: "AspNetUsers",
                column: "plantId",
                principalTable: "Plants",
                principalColumn: "PlantNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Plants_plantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_plantId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88782a18-18df-402f-82ae-da7bde0441e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fb511cc-3eb3-4bc4-a8e6-904c1a2def61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dc85cd5-4266-4b18-b671-f467b7547460");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aedd3195-3521-417f-92e2-2b90205d3483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3bd7993-5c99-43cc-8ced-843bf00f09de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c54f6a89-2768-444d-b523-b50c6b8c8a1f");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "plantId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02cff984-d02a-456f-9817-a4ff4e2e650e", "5", "FinanceManager", "ItAnalyst" },
                    { "8138017f-5f37-49f5-b620-371858f0e270", "1", "Admin", "Admin" },
                    { "83b9cbca-1c7a-44e9-934b-8af9489e3820", "4", "HrManager", "HrManager" },
                    { "d84da186-e92e-4236-a62d-ffef863d653a", "3", "DeptManager", "DeptManager" },
                    { "ef0fd9e2-466e-4574-9daf-31bbee47dcb4", "5", "FinanceManager", "FinanceManager" },
                    { "fec994ff-0760-44da-8280-7ad08bcf3d16", "2", "User", "User" }
                });
        }
    }
}
