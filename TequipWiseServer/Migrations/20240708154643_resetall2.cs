using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class resetall2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0db92249-bf10-4625-8ece-16eb15304e31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3065fcd3-2d61-4bd7-8449-f9c81618815b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dd5cf5d-d3cd-4a9c-9d90-a07e1422554a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aa9279d-0bb5-4c0c-b84f-27e0ce85d89a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e574c526-f8f3-42e4-ad69-90892e71f746");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26c77823-b716-434e-8b21-fd7851db98ee", "4", "It Approver", "It Approver" },
                    { "39029bb5-d4f2-40c3-8472-7eee70ed61dc", "5", "Controller", "Controller" },
                    { "a827ad36-bd51-475a-8065-96cbf8e4b602", "3", "Manager", "Manager" },
                    { "ad04e118-0a3d-4c42-957b-088d8f9a5b25", "1", "Admin", "Admin" },
                    { "c4a1b9ab-9da6-41d3-8819-93a9fb0646d5", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c77823-b716-434e-8b21-fd7851db98ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39029bb5-d4f2-40c3-8472-7eee70ed61dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a827ad36-bd51-475a-8065-96cbf8e4b602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad04e118-0a3d-4c42-957b-088d8f9a5b25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4a1b9ab-9da6-41d3-8819-93a9fb0646d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0db92249-bf10-4625-8ece-16eb15304e31", "3", "Manager", "Manager" },
                    { "3065fcd3-2d61-4bd7-8449-f9c81618815b", "4", "It Approver", "It Approver" },
                    { "3dd5cf5d-d3cd-4a9c-9d90-a07e1422554a", "5", "Controller", "Controller" },
                    { "8aa9279d-0bb5-4c0c-b84f-27e0ce85d89a", "2", "User", "User" },
                    { "e574c526-f8f3-42e4-ad69-90892e71f746", "1", "Admin", "Admin" }
                });
        }
    }
}
