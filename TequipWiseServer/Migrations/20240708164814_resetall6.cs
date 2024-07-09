using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class resetall6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SapNumbers_AspNetUsers_ControllerId1",
                table: "SapNumbers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2e2a9c-9804-48f3-abbb-f4549a883541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d778233-5747-4d7c-b87f-09b8f99525cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ebe101e-dd98-4e7d-a672-00c3b1ad7e44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eca3965-12d8-49ea-ad84-e0536fca7697");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d56bdf4a-575a-4809-b839-7c940b948da7");

            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "SapNumbers");

            migrationBuilder.RenameColumn(
                name: "ControllerId1",
                table: "SapNumbers",
                newName: "Idcontroller");

            migrationBuilder.RenameIndex(
                name: "IX_SapNumbers_ControllerId1",
                table: "SapNumbers",
                newName: "IX_SapNumbers_Idcontroller");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2169f318-baca-4cc3-bf19-3facc2181229", "1", "Admin", "Admin" },
                    { "65a7cc43-7fd3-4fb9-8334-c486c79b6ff6", "4", "It Approver", "It Approver" },
                    { "8a520efa-3f0a-46ac-81d9-232e830b6d8f", "2", "User", "User" },
                    { "d4329b69-a807-4351-a710-ef61c7716864", "5", "Controller", "Controller" },
                    { "db816a9c-5a5a-45a9-b187-29522d244503", "3", "Manager", "Manager" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SapNumbers_AspNetUsers_Idcontroller",
                table: "SapNumbers",
                column: "Idcontroller",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SapNumbers_AspNetUsers_Idcontroller",
                table: "SapNumbers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2169f318-baca-4cc3-bf19-3facc2181229");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65a7cc43-7fd3-4fb9-8334-c486c79b6ff6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a520efa-3f0a-46ac-81d9-232e830b6d8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4329b69-a807-4351-a710-ef61c7716864");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db816a9c-5a5a-45a9-b187-29522d244503");

            migrationBuilder.RenameColumn(
                name: "Idcontroller",
                table: "SapNumbers",
                newName: "ControllerId1");

            migrationBuilder.RenameIndex(
                name: "IX_SapNumbers_Idcontroller",
                table: "SapNumbers",
                newName: "IX_SapNumbers_ControllerId1");

            migrationBuilder.AddColumn<string>(
                name: "ControllerId",
                table: "SapNumbers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a2e2a9c-9804-48f3-abbb-f4549a883541", "3", "Manager", "Manager" },
                    { "6d778233-5747-4d7c-b87f-09b8f99525cb", "4", "It Approver", "It Approver" },
                    { "6ebe101e-dd98-4e7d-a672-00c3b1ad7e44", "2", "User", "User" },
                    { "9eca3965-12d8-49ea-ad84-e0536fca7697", "1", "Admin", "Admin" },
                    { "d56bdf4a-575a-4809-b839-7c940b948da7", "5", "Controller", "Controller" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SapNumbers_AspNetUsers_ControllerId1",
                table: "SapNumbers",
                column: "ControllerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
