using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixissues1 : Migration
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
                keyValue: "07706726-fd7b-44b8-9043-3ab28ac998f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b33be02-fe61-474a-8680-148b0aeb22eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "445da020-c12d-48f5-a614-3c911252cb2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44f9875c-3303-4134-8861-0eb4038b9a83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c42a723-6fe5-49a1-8199-7315a91fdbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed8a60e5-96d9-407a-a437-3e274c6ef353");

            migrationBuilder.DropColumn(
                name: "LocationId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07706726-fd7b-44b8-9043-3ab28ac998f2", "3", "DeptManager", "DeptManager" },
                    { "1b33be02-fe61-474a-8680-148b0aeb22eb", "4", "HrManager", "HrManager" },
                    { "445da020-c12d-48f5-a614-3c911252cb2b", "5", "FinanceManager", "FinanceManager" },
                    { "44f9875c-3303-4134-8861-0eb4038b9a83", "2", "User", "User" },
                    { "6c42a723-6fe5-49a1-8199-7315a91fdbbf", "1", "Admin", "Admin" },
                    { "ed8a60e5-96d9-407a-a437-3e274c6ef353", "5", "FinanceManager", "ItAnalyst" }
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
