using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class changes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24132a43-d5ca-4be5-b6b6-0f5cf4bc9b91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246c1918-0789-460e-bb1b-d4a176d3d252");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d44a09-e5a8-4bb6-930f-30377a5c5bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea0446ea-c5d7-443b-be8f-0861d81250a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef08ad59-1fc1-459b-b81c-f2f76ce3b881");

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0442b931-a4e6-4e26-9b0e-a1be3e44d681", "1", "Admin", "Admin" },
                    { "27516e38-227b-46ba-970f-914a42bf4436", "4", "It Approver", "It Approver" },
                    { "4c9d6a19-cf13-401a-b3ce-9bd6dd82bc25", "2", "User", "User" },
                    { "92952056-8e50-4d26-8762-4b4783a5f8d4", "3", "Manager", "Manager" },
                    { "b306746d-2154-494a-b510-028d5fde285e", "5", "Controller", "Controller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0442b931-a4e6-4e26-9b0e-a1be3e44d681");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27516e38-227b-46ba-970f-914a42bf4436");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c9d6a19-cf13-401a-b3ce-9bd6dd82bc25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92952056-8e50-4d26-8762-4b4783a5f8d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b306746d-2154-494a-b510-028d5fde285e");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "subEquipmentRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24132a43-d5ca-4be5-b6b6-0f5cf4bc9b91", "2", "User", "User" },
                    { "246c1918-0789-460e-bb1b-d4a176d3d252", "4", "It Approver", "It Approver" },
                    { "41d44a09-e5a8-4bb6-930f-30377a5c5bc2", "3", "Manager", "Manager" },
                    { "ea0446ea-c5d7-443b-be8f-0861d81250a3", "1", "Admin", "Admin" },
                    { "ef08ad59-1fc1-459b-b81c-f2f76ce3b881", "5", "Controller", "Controller" }
                });
        }
    }
}
