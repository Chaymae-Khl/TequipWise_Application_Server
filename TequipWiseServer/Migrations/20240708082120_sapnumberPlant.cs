using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class sapnumberPlant : Migration
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
                keyValue: "23201a6a-a047-40ed-9b32-4788c684e564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "866407e9-e332-4b1f-9ec9-104596596897");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a5e0f8a-0776-407a-baf5-6c710c623a40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcc7a254-59b4-4db1-8e63-39e95ecd1355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1707d9f-75fb-40e9-bebb-84b208e9f72f");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Plants");

            migrationBuilder.CreateTable(
                name: "SapNumbers",
                columns: table => new
                {
                    SApID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SapNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantNumber = table.Column<int>(type: "int", nullable: false),
                    ControllerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    { "162f2c52-6ef6-4ea6-b2e3-218835a346a1", "4", "It Approver", "It Approver" },
                    { "1c2b4b08-8db3-426b-a236-db1cbbcaece7", "2", "User", "User" },
                    { "2ffe44db-8cf4-417e-995e-3cdbec080c1f", "3", "Manager", "Manager" },
                    { "445f914f-460b-41e0-bedb-46ea06eb4dda", "1", "Admin", "Admin" },
                    { "6c1ca56b-453e-4afd-874a-cf65ba271c52", "5", "Controller", "Controller" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SapNumbers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "162f2c52-6ef6-4ea6-b2e3-218835a346a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c2b4b08-8db3-426b-a236-db1cbbcaece7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ffe44db-8cf4-417e-995e-3cdbec080c1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "445f914f-460b-41e0-bedb-46ea06eb4dda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c1ca56b-453e-4afd-874a-cf65ba271c52");

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
                    { "23201a6a-a047-40ed-9b32-4788c684e564", "1", "Admin", "Admin" },
                    { "866407e9-e332-4b1f-9ec9-104596596897", "5", "Controller", "Controller" },
                    { "9a5e0f8a-0776-407a-baf5-6c710c623a40", "2", "User", "User" },
                    { "bcc7a254-59b4-4db1-8e63-39e95ecd1355", "3", "Manager", "Manager" },
                    { "d1707d9f-75fb-40e9-bebb-84b208e9f72f", "4", "It Approver", "It Approver" }
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
