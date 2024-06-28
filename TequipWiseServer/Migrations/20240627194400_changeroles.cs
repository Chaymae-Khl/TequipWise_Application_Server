using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class changeroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20053745-4451-424a-849d-375ec0b39646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5df8d28b-9fca-4087-b71c-fb389edb47ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7be5df03-07d6-4d81-b61a-61456e931c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f43ffb7e-353b-4a72-af6c-e9a8d746f249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff36a610-cc72-48e4-b007-d2828e51b830");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20053745-4451-424a-849d-375ec0b39646", "5", "Controller", "Controller" },
                    { "5df8d28b-9fca-4087-b71c-fb389edb47ed", "4", "ItAnalyst", "ItAnalyst" },
                    { "7be5df03-07d6-4d81-b61a-61456e931c03", "1", "Admin", "Admin" },
                    { "f43ffb7e-353b-4a72-af6c-e9a8d746f249", "2", "User", "User" },
                    { "ff36a610-cc72-48e4-b007-d2828e51b830", "3", "DeptManager", "DeptManager" }
                });
        }
    }
}
