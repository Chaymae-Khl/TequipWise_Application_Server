using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class initial0ValueToprices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1767fb01-9529-4803-aa38-2b3fbd0757e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61c23588-c403-4ff2-99a5-b105bc5c5c22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "801e1bc0-97df-4fca-bb2a-0935aae2c539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8441c60b-0a1f-4639-b52a-1197fdff3628");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db499bf2-3de9-4c79-a894-3dff72eb7c86");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eee7eee-c752-4a60-82b8-4abd5db7ec85", "3", "Manager", "Manager" },
                    { "1f2978ff-a9b5-4f71-b32b-3fc38b52dd30", "2", "User", "User" },
                    { "28518a24-849f-4295-b96d-013652bbe475", "4", "It Approver", "It Approver" },
                    { "9a3c6af5-cbba-41be-9b1e-ce8f8f4bd0ed", "5", "Controller", "Controller" },
                    { "ff604a59-167b-487f-a204-834220a010a1", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eee7eee-c752-4a60-82b8-4abd5db7ec85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f2978ff-a9b5-4f71-b32b-3fc38b52dd30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28518a24-849f-4295-b96d-013652bbe475");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a3c6af5-cbba-41be-9b1e-ce8f8f4bd0ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff604a59-167b-487f-a204-834220a010a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1767fb01-9529-4803-aa38-2b3fbd0757e4", "5", "Controller", "Controller" },
                    { "61c23588-c403-4ff2-99a5-b105bc5c5c22", "4", "It Approver", "It Approver" },
                    { "801e1bc0-97df-4fca-bb2a-0935aae2c539", "1", "Admin", "Admin" },
                    { "8441c60b-0a1f-4639-b52a-1197fdff3628", "3", "Manager", "Manager" },
                    { "db499bf2-3de9-4c79-a894-3dff72eb7c86", "2", "User", "User" }
                });
        }
    }
}
