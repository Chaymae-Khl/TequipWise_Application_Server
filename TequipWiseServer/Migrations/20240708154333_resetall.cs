using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class resetall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SapNumbers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "077b7fe2-d81a-42f5-9d20-f798fddadd83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56253471-8e78-4c28-abcd-defa02129f9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9bdba6-ba89-43a0-8b60-831be6de415b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4904477-db14-4a89-bcae-fd390080198e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd568337-159f-4bf6-9475-f506331cf624");

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
                    { "0db92249-bf10-4625-8ece-16eb15304e31", "3", "Manager", "Manager" },
                    { "3065fcd3-2d61-4bd7-8449-f9c81618815b", "4", "It Approver", "It Approver" },
                    { "3dd5cf5d-d3cd-4a9c-9d90-a07e1422554a", "5", "Controller", "Controller" },
                    { "8aa9279d-0bb5-4c0c-b84f-27e0ce85d89a", "2", "User", "User" },
                    { "e574c526-f8f3-42e4-ad69-90892e71f746", "1", "Admin", "Admin" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Plants");

            migrationBuilder.CreateTable(
                name: "SapNumbers",
                columns: table => new
                {
                    SApID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControllerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlantNumber = table.Column<int>(type: "int", nullable: false),
                    SapNum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapNumbers", x => x.SApID);
                    table.ForeignKey(
                        name: "FK_SapNumbers_AspNetUsers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SapNumbers_Plants_PlantNumber",
                        column: x => x.PlantNumber,
                        principalTable: "Plants",
                        principalColumn: "PlantNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "077b7fe2-d81a-42f5-9d20-f798fddadd83", "3", "Manager", "Manager" },
                    { "56253471-8e78-4c28-abcd-defa02129f9e", "2", "User", "User" },
                    { "9c9bdba6-ba89-43a0-8b60-831be6de415b", "1", "Admin", "Admin" },
                    { "e4904477-db14-4a89-bcae-fd390080198e", "4", "It Approver", "It Approver" },
                    { "fd568337-159f-4bf6-9475-f506331cf624", "5", "Controller", "Controller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SapNumbers_ControllerId",
                table: "SapNumbers",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_SapNumbers_PlantNumber",
                table: "SapNumbers",
                column: "PlantNumber");
        }
    }
}
