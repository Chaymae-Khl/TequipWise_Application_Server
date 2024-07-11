using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class assignNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cd082a2-a816-46b7-80fd-534ef8c4f28d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4533950b-2de5-4c8e-987d-f8458c82f0b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832c6675-291f-44bd-9c46-69adb8ab41af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90cb1ee9-f67b-4659-b91e-5d68979889fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6eab4f9-2293-4d1c-83d9-538677e7cc68");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cd082a2-a816-46b7-80fd-534ef8c4f28d", "2", "User", "User" },
                    { "4533950b-2de5-4c8e-987d-f8458c82f0b0", "4", "It Approver", "It Approver" },
                    { "832c6675-291f-44bd-9c46-69adb8ab41af", "5", "Controller", "Controller" },
                    { "90cb1ee9-f67b-4659-b91e-5d68979889fe", "1", "Admin", "Admin" },
                    { "d6eab4f9-2293-4d1c-83d9-538677e7cc68", "3", "Manager", "Manager" }
                });
        }
    }
}
