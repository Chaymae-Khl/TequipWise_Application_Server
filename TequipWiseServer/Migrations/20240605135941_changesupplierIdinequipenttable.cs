using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class changesupplierIdinequipenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Suppliers_SupplierId",
                table: "Equipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6841f2ee-24f9-4a39-9da4-ee433b5c9c38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcecfef-db33-40af-9d07-0ee33fa45e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82b4a9a0-2b04-4671-a5f3-784190d35923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92819e02-0924-4db4-b6eb-34f7695cc196");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7b5d9b1-329e-49f0-af6f-e46028301dca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc0bd085-24a6-4215-b39f-1b5d4d261689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed6a3fd-5ea4-41dc-9c47-5d0a22d88d03");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Equipments",
                newName: "supplierrid");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_SupplierId",
                table: "Equipments",
                newName: "IX_Equipments_supplierrid");

          

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Suppliers_supplierrid",
                table: "Equipments",
                column: "supplierrid",
                principalTable: "Suppliers",
                principalColumn: "SuplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Suppliers_supplierrid",
                table: "Equipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35287080-727b-47ed-8296-838a2571d41c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4277baf9-ec06-418d-805c-03828e2087db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61699613-9067-4e0b-ac65-302717a01fe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad3ef6ed-2aed-452b-a573-2921af770deb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af4a25d0-5094-46b6-8ff1-475de5e32cfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d97ce497-4f90-4ef2-91be-4e2d02003f8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6430c08-4644-4bdf-aab3-9b412396794a");

            migrationBuilder.RenameColumn(
                name: "supplierrid",
                table: "Equipments",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_supplierrid",
                table: "Equipments",
                newName: "IX_Equipments_SupplierId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6841f2ee-24f9-4a39-9da4-ee433b5c9c38", "3", "DeptManager", "DeptManager" },
                    { "7bcecfef-db33-40af-9d07-0ee33fa45e02", "1", "Admin", "Admin" },
                    { "82b4a9a0-2b04-4671-a5f3-784190d35923", "7", "Controller", "Controller" },
                    { "92819e02-0924-4db4-b6eb-34f7695cc196", "2", "User", "User" },
                    { "a7b5d9b1-329e-49f0-af6f-e46028301dca", "5", "FinanceManager", "FinanceManager" },
                    { "dc0bd085-24a6-4215-b39f-1b5d4d261689", "6", "ItAnalyst", "ItAnalyst" },
                    { "eed6a3fd-5ea4-41dc-9c47-5d0a22d88d03", "4", "HrManager", "HrManager" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Suppliers_SupplierId",
                table: "Equipments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SuplierId");
        }
    }
}
