using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newhirerBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "247cddb8-f622-4eed-afcb-30c723a04ce9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51a45d16-76b7-4627-9fb3-6a5b2a31cccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73013f03-d19b-40d3-a2cf-f1e2d42fc73d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7593f447-cd0e-4b5a-bbd9-50901dcf27b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d90897d-fddc-4db5-aa52-e81c5b699f11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6f7e0b-f2b1-4e4d-9c50-3ab441c2af59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebbef6a5-45f6-432f-9538-27a732a5e0a0");

            migrationBuilder.DropColumn(
                name: "NewhireName",
                table: "UserEquipmentRequests");

            migrationBuilder.AddColumn<bool>(
                name: "isNewhire",
                table: "UserEquipmentRequests",
                type: "bit",
                nullable: true);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b52cbf7-f2ee-4c29-85ce-7971489ed90a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73d2889f-4e7e-4fd6-b2a6-2557e4f0daa0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "985fc659-78df-4f82-83f2-a725be2e71aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9baaaa1a-2fd2-4a91-966f-441e378a22f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e02cc845-2e3b-4e44-a2f0-8be866dd3c57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0513fe4-2c6b-4246-a3ca-954a689bddf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa57fc1f-e6a0-483c-8ff3-81114be6c43d");

            migrationBuilder.DropColumn(
                name: "isNewhire",
                table: "UserEquipmentRequests");

            migrationBuilder.AddColumn<string>(
                name: "NewhireName",
                table: "UserEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "247cddb8-f622-4eed-afcb-30c723a04ce9", "6", "ItAnalyst", "ItAnalyst" },
                    { "51a45d16-76b7-4627-9fb3-6a5b2a31cccf", "4", "HrManager", "HrManager" },
                    { "73013f03-d19b-40d3-a2cf-f1e2d42fc73d", "1", "Admin", "Admin" },
                    { "7593f447-cd0e-4b5a-bbd9-50901dcf27b1", "7", "Controller", "Controller" },
                    { "7d90897d-fddc-4db5-aa52-e81c5b699f11", "2", "User", "User" },
                    { "8d6f7e0b-f2b1-4e4d-9c50-3ab441c2af59", "3", "DeptManager", "DeptManager" },
                    { "ebbef6a5-45f6-432f-9538-27a732a5e0a0", "5", "FinanceManager", "FinanceManager" }
                });
        }
    }
}
