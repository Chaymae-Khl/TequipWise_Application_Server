using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class resetall4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_ApproverId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_ApproverId",
                table: "Plants");

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

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Plants");

            migrationBuilder.AddColumn<int>(
                name: "SapNumberId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SapNumbers",
                columns: table => new
                {
                    SApID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SapNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapNumbers", x => x.SApID);
                    table.ForeignKey(
                        name: "FK_SapNumbers_AspNetUsers_ControllerId1",
                        column: x => x.ControllerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SapNumberId",
                table: "AspNetUsers",
                column: "SapNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_SapNumbers_ControllerId1",
                table: "SapNumbers",
                column: "ControllerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SapNumbers_SapNumberId",
                table: "AspNetUsers",
                column: "SapNumberId",
                principalTable: "SapNumbers",
                principalColumn: "SApID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SapNumbers_SapNumberId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SapNumbers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SapNumberId",
                table: "AspNetUsers");

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
                name: "SapNumberId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApproverId",
                table: "Plants",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ApproverId",
                table: "Plants",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_ApproverId",
                table: "Plants",
                column: "ApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
