using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class addapproversToRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0404f9ae-852a-4f38-8f65-cba39b51104b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b3930c1-343c-41d1-9705-426a7991985c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21628344-20fd-49e1-847e-632993c5cb0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95d2693f-41f8-43ed-9600-b5f48079b12e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f699e2a9-9caa-4009-84d1-4cfe11a125f6");

            migrationBuilder.AddColumn<string>(
                name: "DeparManagId",
                table: "UserEquipmentRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "controllerid",
                table: "UserEquipmentRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deptManagId",
                table: "UserEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "itId",
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
                name: "IX_UserEquipmentRequests_controllerid",
                table: "UserEquipmentRequests",
                column: "controllerid");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_DeparManagId",
                table: "UserEquipmentRequests",
                column: "DeparManagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_itId",
                table: "UserEquipmentRequests",
                column: "itId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_DeparManagId",
                table: "UserEquipmentRequests",
                column: "DeparManagId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_controllerid",
                table: "UserEquipmentRequests",
                column: "controllerid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_itId",
                table: "UserEquipmentRequests",
                column: "itId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_DeparManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_controllerid",
                table: "UserEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEquipmentRequests_AspNetUsers_itId",
                table: "UserEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserEquipmentRequests_controllerid",
                table: "UserEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserEquipmentRequests_DeparManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserEquipmentRequests_itId",
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

            migrationBuilder.DropColumn(
                name: "controllerid",
                table: "UserEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "deptManagId",
                table: "UserEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "itId",
                table: "UserEquipmentRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0404f9ae-852a-4f38-8f65-cba39b51104b", "5", "Controller", "Controller" },
                    { "1b3930c1-343c-41d1-9705-426a7991985c", "2", "User", "User" },
                    { "21628344-20fd-49e1-847e-632993c5cb0a", "4", "ItAnalyst", "ItAnalyst" },
                    { "95d2693f-41f8-43ed-9600-b5f48079b12e", "1", "Admin", "Admin" },
                    { "f699e2a9-9caa-4009-84d1-4cfe11a125f6", "3", "DeptManager", "DeptManager" }
                });
        }
    }
}
