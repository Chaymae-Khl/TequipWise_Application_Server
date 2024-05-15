using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigrationatoupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f296e9c-0f3c-456c-9c7e-335b6285acb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ad889fa-b775-4d8d-95fb-d320d3a5fa43");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Plant_Manager",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApproverId",
                table: "Plants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BackupaproverId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StatusBackupProvider",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a47b55c-c91f-4dab-8f7e-bfd1002f8d72", "2", "User", "User" },
                    { "90bc3d23-43d5-42bc-bc53-e4937b3964ee", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ApproverId",
                table: "Plants",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BackupaproverId",
                table: "AspNetUsers",
                column: "BackupaproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BackupaproverId",
                table: "AspNetUsers",
                column: "BackupaproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_ApproverId",
                table: "Plants",
                column: "ApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BackupaproverId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_ApproverId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_ApproverId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BackupaproverId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a47b55c-c91f-4dab-8f7e-bfd1002f8d72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90bc3d23-43d5-42bc-bc53-e4937b3964ee");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "BackupaproverId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatusBackupProvider",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plant_Manager",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f296e9c-0f3c-456c-9c7e-335b6285acb9", "2", "User", "User" },
                    { "7ad889fa-b775-4d8d-95fb-d320d3a5fa43", "1", "Admin", "Admin" }
                });
        }
    }
}
