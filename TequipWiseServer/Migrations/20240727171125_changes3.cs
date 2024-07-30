using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class changes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66980243-815b-41b0-8781-fb47c7a1e35b", "5", "Controller", "Controller" },
                    { "7fc086b9-875c-4560-8e17-6733fe4b5fa7", "1", "Admin", "Admin" },
                    { "9093bf41-de98-4f97-8714-707f63c617e9", "2", "User", "User" },
                    { "ae8878a6-912a-43f8-bd79-00dc27095e58", "4", "It Approver", "It Approver" },
                    { "d52a3b5e-d2a4-439d-9885-92a3b15b3ba5", "3", "Manager", "Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66980243-815b-41b0-8781-fb47c7a1e35b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fc086b9-875c-4560-8e17-6733fe4b5fa7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9093bf41-de98-4f97-8714-707f63c617e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae8878a6-912a-43f8-bd79-00dc27095e58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d52a3b5e-d2a4-439d-9885-92a3b15b3ba5");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "EquipmentRequests");

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
    }
}
