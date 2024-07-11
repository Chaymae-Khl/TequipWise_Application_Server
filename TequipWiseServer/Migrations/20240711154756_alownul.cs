using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class alownul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bed75bc-efc0-4bba-b01b-2745edeffd2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a8441b-e899-418a-9fb2-5bea17f2b102");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "732bd401-b39b-4c88-88fe-158d67aba1ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b92840-6863-4dbb-a048-b18c9454ba0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd116af2-9629-4769-8913-f263c2753173");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1767fb01-9529-4803-aa38-2b3fbd0757e4", "5", "Controller", "Controller" },
                    { "61c23588-c403-4ff2-99a5-b105bc5c5c22", "4", "It Approver", "It Approver" },
                    { "801e1bc0-97df-4fca-bb2a-0935aae2c539", "1", "Admin", "Admin" },
                    { "8441c60b-0a1f-4639-b52a-1197fdff3628", "3", "Manager", "Manager" },
                    { "db499bf2-3de9-4c79-a894-3dff72eb7c86", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1767fb01-9529-4803-aa38-2b3fbd0757e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61c23588-c403-4ff2-99a5-b105bc5c5c22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "801e1bc0-97df-4fca-bb2a-0935aae2c539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8441c60b-0a1f-4639-b52a-1197fdff3628");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db499bf2-3de9-4c79-a894-3dff72eb7c86");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bed75bc-efc0-4bba-b01b-2745edeffd2d", "1", "Admin", "Admin" },
                    { "54a8441b-e899-418a-9fb2-5bea17f2b102", "5", "Controller", "Controller" },
                    { "732bd401-b39b-4c88-88fe-158d67aba1ea", "3", "Manager", "Manager" },
                    { "84b92840-6863-4dbb-a048-b18c9454ba0c", "2", "User", "User" },
                    { "bd116af2-9629-4769-8913-f263c2753173", "4", "It Approver", "It Approver" }
                });
        }
    }
}
