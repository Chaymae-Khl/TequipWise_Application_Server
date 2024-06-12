using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class prCause : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_UserId",
                table: "UserEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "188629e8-f40a-4091-b915-505265908003");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3395db37-3ecd-42dc-b4c9-b1a481e555ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40e8a622-4949-4b87-b69c-e85fdc0dbc0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f9c8b57-24cd-439d-be3f-f66488a6a891");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b4a5b1d-181b-4cce-99c0-80c2693ff224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4b6a298-c475-4299-ae24-d52df1fac9dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db86c9d9-955e-40c6-b7ca-b0567e7bdecc");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserEquipmentRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PR_Not_ConfirmCause",
                table: "UserEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PR_Status",
                table: "UserEquipmentRequests",
                type: "bit",
                nullable: true);

          

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_UserId",
                table: "UserEquipmentRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_UserId",
                table: "UserEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "038590b7-52bf-47d0-ab08-5fa122ee3ea4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c9aac28-2d32-4cf8-b0bd-a0b6d5a38963");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c8ac29-821a-47ab-8ae3-a695777a518b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33c6f827-8fb2-4cda-b861-05621f3f6a90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e28afea-d263-48ba-bf38-42f736bc2869");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9573da3c-6a18-4f1e-83e6-f0a975bcbfa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef059a7b-19d1-4e9a-96d3-63fc7a5fb085");

            migrationBuilder.DropColumn(
                name: "PR_Not_ConfirmCause",
                table: "UserEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PR_Status",
                table: "UserEquipmentRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserEquipmentRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "188629e8-f40a-4091-b915-505265908003", "5", "FinanceManager", "FinanceManager" },
                    { "3395db37-3ecd-42dc-b4c9-b1a481e555ea", "6", "ItAnalyst", "ItAnalyst" },
                    { "40e8a622-4949-4b87-b69c-e85fdc0dbc0b", "7", "Controller", "Controller" },
                    { "4f9c8b57-24cd-439d-be3f-f66488a6a891", "3", "DeptManager", "DeptManager" },
                    { "5b4a5b1d-181b-4cce-99c0-80c2693ff224", "4", "HrManager", "HrManager" },
                    { "d4b6a298-c475-4299-ae24-d52df1fac9dd", "2", "User", "User" },
                    { "db86c9d9-955e-40c6-b7ca-b0567e7bdecc", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_UserId",
                table: "UserEquipmentRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
