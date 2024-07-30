using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f584139-0312-4217-8e49-45cae044c5db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "127c3770-3ed5-49fb-a5e6-f29970ebc8f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57f936f3-3fc8-412a-82a5-9d3277488348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b69938c-7f03-4f9b-9f8f-383be5514c22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03ba0e1-b0dc-48c0-b846-f9c9cc661097");

            migrationBuilder.DropColumn(
                name: "CC",
                table: "EquipmentRequests");

            migrationBuilder.DropColumn(
                name: "GL",
                table: "EquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PONum",
                table: "EquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PRNum",
                table: "EquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PR_Not_ConfirmCause",
                table: "EquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PR_Status",
                table: "EquipmentRequests");

            migrationBuilder.DropColumn(
                name: "order",
                table: "EquipmentRequests");

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GL",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PONum",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PRNum",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PR_Not_ConfirmCause",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PR_Status",
                table: "subEquipmentRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "order",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CC",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "GL",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PONum",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PRNum",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PR_Not_ConfirmCause",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "PR_Status",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "order",
                table: "subEquipmentRequests");

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GL",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PONum",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PRNum",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PR_Not_ConfirmCause",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PR_Status",
                table: "EquipmentRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "order",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f584139-0312-4217-8e49-45cae044c5db", "4", "It Approver", "It Approver" },
                    { "127c3770-3ed5-49fb-a5e6-f29970ebc8f2", "1", "Admin", "Admin" },
                    { "57f936f3-3fc8-412a-82a5-9d3277488348", "3", "Manager", "Manager" },
                    { "6b69938c-7f03-4f9b-9f8f-383be5514c22", "5", "Controller", "Controller" },
                    { "a03ba0e1-b0dc-48c0-b846-f9c9cc661097", "2", "User", "User" }
                });
        }
    }
}
