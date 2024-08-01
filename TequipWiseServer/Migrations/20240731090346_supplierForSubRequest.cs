using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class supplierForSubRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "supplierrid",
                table: "subEquipmentRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4423dc10-2d66-499a-a9ad-f3d33d23057f", "3", "Manager", "Manager" },
                    { "484f1514-3cce-4fde-88f3-e7cc29df855f", "4", "It Approver", "It Approver" },
                    { "4e7b0d48-07aa-42b6-b599-0b97f4ebf5fe", "1", "Admin", "Admin" },
                    { "5889aead-77e0-4f75-a2b2-290f6eeb9a0a", "2", "User", "User" },
                    { "e7d3cf42-32b5-43bb-a112-a126435f6b01", "5", "Controller", "Controller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_supplierrid",
                table: "subEquipmentRequests",
                column: "supplierrid");

            migrationBuilder.AddForeignKey(
                name: "FK_subEquipmentRequests_Suppliers_supplierrid",
                table: "subEquipmentRequests",
                column: "supplierrid",
                principalTable: "Suppliers",
                principalColumn: "SuplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subEquipmentRequests_Suppliers_supplierrid",
                table: "subEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_subEquipmentRequests_supplierrid",
                table: "subEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4423dc10-2d66-499a-a9ad-f3d33d23057f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "484f1514-3cce-4fde-88f3-e7cc29df855f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e7b0d48-07aa-42b6-b599-0b97f4ebf5fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5889aead-77e0-4f75-a2b2-290f6eeb9a0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7d3cf42-32b5-43bb-a112-a126435f6b01");

            migrationBuilder.DropColumn(
                name: "supplierrid",
                table: "subEquipmentRequests");

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
    }
}
