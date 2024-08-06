using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newrolee2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "071816bf-a445-4265-896c-e6e36944dbcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10ded766-1c5f-4558-8019-cca821357f61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fbbbb4e-b387-4665-b486-29344b30456c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3610b8f7-7ebf-4a8b-bc07-f9cd51b208ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41473cf4-2586-4f32-a08d-da44485d15c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77c42556-5ace-4aca-a307-295a61dc1cdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8767c14e-4b2b-4442-b604-c9f29ec85b1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96933c16-89e6-485d-bb73-f7dd2d73a726");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d184d9e4-6867-4828-8ac2-b0fee0847af0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07dc44a0-1c86-4768-964f-e75803046750", "9", "Approver", "Approver" },
                    { "1b8edbe0-5762-4569-bc5e-99e483deff47", "5", "Controller", "Controller" },
                    { "3c25c134-75dd-42d9-a7e1-1fd1e21f4446", "2", "User", "User" },
                    { "6b3fd1a8-1d0b-4bf1-853f-13917ba55793", "6", "ManagerBackupApprover", "ManagerBackupApprover" },
                    { "7ade7591-00fd-41b1-89b6-987d66a3fcae", "1", "Admin", "Admin" },
                    { "82748eb6-957f-4855-8af0-09f78fd72dce", "3", "Manager", "Manager" },
                    { "9a47a643-00c0-4805-b099-75a4a85f5166", "8", "ControllerBackupApprover", "ControllerBackupApprover" },
                    { "d13e1ebb-3bf4-40b7-ab72-b97aaeac3101", "7", "ItBackupApprover", "ItBackupApprover" },
                    { "ef5151dd-3e5a-47e4-9cca-24dc365ee4b7", "4", "It Approver", "It Approver" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07dc44a0-1c86-4768-964f-e75803046750");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8edbe0-5762-4569-bc5e-99e483deff47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c25c134-75dd-42d9-a7e1-1fd1e21f4446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b3fd1a8-1d0b-4bf1-853f-13917ba55793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ade7591-00fd-41b1-89b6-987d66a3fcae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82748eb6-957f-4855-8af0-09f78fd72dce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a47a643-00c0-4805-b099-75a4a85f5166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d13e1ebb-3bf4-40b7-ab72-b97aaeac3101");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef5151dd-3e5a-47e4-9cca-24dc365ee4b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "071816bf-a445-4265-896c-e6e36944dbcf", "5", "Controller", "Controller" },
                    { "10ded766-1c5f-4558-8019-cca821357f61", "8", "ControllerBackupApprover", "ControllerBackupApprover" },
                    { "2fbbbb4e-b387-4665-b486-29344b30456c", "4", "It Approver", "It Approver" },
                    { "3610b8f7-7ebf-4a8b-bc07-f9cd51b208ee", "7", "ItBackupApprover", "ItBackupApprover" },
                    { "41473cf4-2586-4f32-a08d-da44485d15c9", "6", "ManagerBackupApprover", "ManagerBackupApprover" },
                    { "77c42556-5ace-4aca-a307-295a61dc1cdf", "2", "User", "User" },
                    { "8767c14e-4b2b-4442-b604-c9f29ec85b1c", "3", "Manager", "Manager" },
                    { "96933c16-89e6-485d-bb73-f7dd2d73a726", "9", "Approver", "Approver" },
                    { "d184d9e4-6867-4828-8ac2-b0fee0847af0", "1", "Admin", "Admin" }
                });
        }
    }
}
