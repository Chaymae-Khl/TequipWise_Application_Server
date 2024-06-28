using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class addItApprover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b68d426-a7cd-4ab4-855e-79ebc0f77dca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34c0809b-91e1-4a33-825a-5c77c93c306e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "444a5eec-ec36-4e44-b7a8-20e21cec606c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c450574-e63a-4a5e-9edb-60c6bb63811e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "836cb2a7-17e7-4d6f-8134-eb842145d5e0");

            migrationBuilder.AddColumn<string>(
                name: "ITApproverId",
                table: "Plants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a375319d-e0b6-4f54-810d-f6c6182eb2ff", "3", "Manager", "Manager" },
                    { "b247fc4f-68e0-4967-9160-3c06cc703c05", "1", "Admin", "Admin" },
                    { "c5a41980-2c7a-43ab-a260-fa45004f8df1", "2", "User", "User" },
                    { "e7456689-2b34-4f99-a76d-8fa9040d553d", "4", "It Approver", "It Approver" },
                    { "ff7fea80-ca99-4615-a3d1-5d50cf5fad80", "5", "Controller", "Controller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ITApproverId",
                table: "Plants",
                column: "ITApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_ITApproverId",
                table: "Plants",
                column: "ITApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_ITApproverId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_ITApproverId",
                table: "Plants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a375319d-e0b6-4f54-810d-f6c6182eb2ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b247fc4f-68e0-4967-9160-3c06cc703c05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a41980-2c7a-43ab-a260-fa45004f8df1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7456689-2b34-4f99-a76d-8fa9040d553d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7fea80-ca99-4615-a3d1-5d50cf5fad80");

            migrationBuilder.DropColumn(
                name: "ITApproverId",
                table: "Plants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b68d426-a7cd-4ab4-855e-79ebc0f77dca", "1", "Admin", "Admin" },
                    { "34c0809b-91e1-4a33-825a-5c77c93c306e", "5", "Controller", "Controller" },
                    { "444a5eec-ec36-4e44-b7a8-20e21cec606c", "2", "User", "User" },
                    { "5c450574-e63a-4a5e-9edb-60c6bb63811e", "4", "It Approver", "It Approver" },
                    { "836cb2a7-17e7-4d6f-8134-eb842145d5e0", "3", "Manager", "Manager" }
                });
        }
    }
}
