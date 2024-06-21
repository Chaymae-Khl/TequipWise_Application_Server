using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class addapproversToRequest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_DeparManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserEquipmentRequests_DeparManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "013b2101-f613-4270-8b8f-15d133206695");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3caa2550-f059-41d8-a067-52d155e1c234");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b53a40a-d034-4408-80ec-b9701c019e59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98859f19-b593-4ffe-9e6a-c4346b05862d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3fc4031-25a5-4f9a-88d1-a56b7556bab0");

            migrationBuilder.DropColumn(
                name: "DeparManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.AlterColumn<string>(
                name: "deptManagId",
                table: "UserEquipmentRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59a5b709-def1-4b0d-9f7c-adb087071992", "4", "ItAnalyst", "ItAnalyst" },
                    { "7cf22072-f884-4aff-a152-a4a97a0bfbeb", "5", "Controller", "Controller" },
                    { "a21c2049-b804-4684-8eeb-41541597d4e5", "3", "DeptManager", "DeptManager" },
                    { "bbba2009-2649-4f30-8f82-0097748ff974", "2", "User", "User" },
                    { "ccffa039-cd5f-4b56-a356-7a11098091d1", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_deptManagId",
                table: "UserEquipmentRequests",
                column: "deptManagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_deptManagId",
                table: "UserEquipmentRequests",
                column: "deptManagId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_deptManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserEquipmentRequests_deptManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59a5b709-def1-4b0d-9f7c-adb087071992");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf22072-f884-4aff-a152-a4a97a0bfbeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21c2049-b804-4684-8eeb-41541597d4e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbba2009-2649-4f30-8f82-0097748ff974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccffa039-cd5f-4b56-a356-7a11098091d1");

            migrationBuilder.AlterColumn<string>(
                name: "deptManagId",
                table: "UserEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeparManagId",
                table: "UserEquipmentRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "013b2101-f613-4270-8b8f-15d133206695", "2", "User", "User" },
                    { "3caa2550-f059-41d8-a067-52d155e1c234", "3", "DeptManager", "DeptManager" },
                    { "4b53a40a-d034-4408-80ec-b9701c019e59", "4", "ItAnalyst", "ItAnalyst" },
                    { "98859f19-b593-4ffe-9e6a-c4346b05862d", "5", "Controller", "Controller" },
                    { "a3fc4031-25a5-4f9a-88d1-a56b7556bab0", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_DeparManagId",
                table: "UserEquipmentRequests",
                column: "DeparManagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_DeparManagId",
                table: "UserEquipmentRequests",
                column: "DeparManagId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
