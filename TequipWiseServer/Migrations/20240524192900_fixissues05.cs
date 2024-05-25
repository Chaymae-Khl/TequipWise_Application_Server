using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixissues05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId",
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
                name: "LocationId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "002b76aa-50ce-4378-9456-e586b83352d9", "3", "DeptManager", "DeptManager" },
                    { "0165b82a-5d62-411f-bdfb-8f2fce6fa066", "2", "User", "User" },
                    { "7e94e1b0-18ae-43ea-91bb-686e79ad7d91", "1", "Admin", "Admin" },
                    { "863b5e64-15ed-4f08-93e5-5aac04f78c06", "5", "FinanceManager", "FinanceManager" },
                    { "8932e5e4-f614-4941-af3e-05aa83bd5269", "4", "HrManager", "HrManager" },
                    { "d7c72976-2829-436a-9d0a-b9487a58519f", "5", "FinanceManager", "ItAnalyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002b76aa-50ce-4378-9456-e586b83352d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0165b82a-5d62-411f-bdfb-8f2fce6fa066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e94e1b0-18ae-43ea-91bb-686e79ad7d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "863b5e64-15ed-4f08-93e5-5aac04f78c06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8932e5e4-f614-4941-af3e-05aa83bd5269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c72976-2829-436a-9d0a-b9487a58519f");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
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
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");
        }
    }
}
