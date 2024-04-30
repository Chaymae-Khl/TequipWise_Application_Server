using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Newmigartion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1645ae83-6dfe-4c56-b608-c5bbf555b1f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b1e5183-cb1c-439a-8da3-3b97e8da43ab");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeNum",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba9ac7cc-bea6-4ad6-b119-6214d54e3bf7", "1", "Admin", "Admin" },
                    { "e7958a45-6d49-48ae-ae50-533dd8eecf11", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9ac7cc-bea6-4ad6-b119-6214d54e3bf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7958a45-6d49-48ae-ae50-533dd8eecf11");

            migrationBuilder.DropColumn(
                name: "TeNum",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1645ae83-6dfe-4c56-b608-c5bbf555b1f5", "2", "User", "User" },
                    { "2b1e5183-cb1c-439a-8da3-3b97e8da43ab", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
