using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class ResevedDataStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "AssetReceiveByEMployeAt",
                table: "subEquipmentRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceptionStatus",
                table: "subEquipmentRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "427e995b-b4e3-486a-b5e6-26c420b1b89d", "5", "Controller", "Controller" },
                    { "6884d8a5-5657-4175-80ef-50e07a8c5989", "4", "It Approver", "It Approver" },
                    { "6e8daf90-c8dd-4601-a27c-ca148119fc77", "3", "Manager", "Manager" },
                    { "6eaf201f-7dbc-4a7c-9b26-11f15aa6942a", "2", "User", "User" },
                    { "7215bac3-859e-43c4-a26f-3e3ab06b5bdc", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "427e995b-b4e3-486a-b5e6-26c420b1b89d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6884d8a5-5657-4175-80ef-50e07a8c5989");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8daf90-c8dd-4601-a27c-ca148119fc77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eaf201f-7dbc-4a7c-9b26-11f15aa6942a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7215bac3-859e-43c4-a26f-3e3ab06b5bdc");

            migrationBuilder.DropColumn(
                name: "AssetReceiveByEMployeAt",
                table: "subEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "ReceptionStatus",
                table: "subEquipmentRequests");

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
        }
    }
}
