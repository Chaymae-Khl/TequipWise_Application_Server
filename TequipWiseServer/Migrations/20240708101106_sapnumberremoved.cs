using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class sapnumberremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "SapNumber",
                table: "Plants");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "SapNumber",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
