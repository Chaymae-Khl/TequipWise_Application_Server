using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class tokenRefresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
