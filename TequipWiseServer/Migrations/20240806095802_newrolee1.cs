using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newrolee1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "104c3de1-4cfe-42ee-b516-0d14231263c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d33fbe-5735-46ac-a47b-aa8c1e466005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "747bb8d4-ad7c-4e31-8910-ee4794112c83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cf40d46-7051-4a6b-989e-954dbcb8b9b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d81fce2-616a-49d5-b79f-d72d72a484c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af6a271-c102-4af1-8b91-0a1551a06566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2c7c398-732b-4592-be93-0561eba43bbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7db5522-8f44-43c7-ae50-1f9a01a5c0f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dde75b13-2c74-4bf7-849a-66f22aa1131f");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "104c3de1-4cfe-42ee-b516-0d14231263c4", "8", "ControllerBackupApprover", "ControllerBackupApprover" },
                    { "23d33fbe-5735-46ac-a47b-aa8c1e466005", "3", "Manager", "Manager" },
                    { "747bb8d4-ad7c-4e31-8910-ee4794112c83", "6", "ManagerBackupApprover", "ManagerBackupApprover" },
                    { "8cf40d46-7051-4a6b-989e-954dbcb8b9b9", "1", "Admin", "Admin" },
                    { "8d81fce2-616a-49d5-b79f-d72d72a484c8", "2", "User", "User" },
                    { "9af6a271-c102-4af1-8b91-0a1551a06566", "5", "Controller", "Controller" },
                    { "a2c7c398-732b-4592-be93-0561eba43bbf", "9", "Approver", "Approver" },
                    { "c7db5522-8f44-43c7-ae50-1f9a01a5c0f6", "4", "It Approver", "It Approver" },
                    { "dde75b13-2c74-4bf7-849a-66f22aa1131f", "7", "ItBackupApprover", "ItBackupApprover" }
                });
        }
    }
}
