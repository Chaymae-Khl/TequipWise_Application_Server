using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class addapproversToRequest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59a5b709-def1-4b0d-9f7c-adb087071992");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf22072-f884-4aff-a152-a4a97a0bfbeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21c2049-b804-4684-8eeb-41541597d4e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbba2009-2649-4f30-8f82-0097748ff974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccffa039-cd5f-4b56-a356-7a11098091d1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "59a5b709-def1-4b0d-9f7c-adb087071992", "4", "ItAnalyst", "ItAnalyst" },
                    { "7cf22072-f884-4aff-a152-a4a97a0bfbeb", "5", "Controller", "Controller" },
                    { "a21c2049-b804-4684-8eeb-41541597d4e5", "3", "DeptManager", "DeptManager" },
                    { "bbba2009-2649-4f30-8f82-0097748ff974", "2", "User", "User" },
                    { "ccffa039-cd5f-4b56-a356-7a11098091d1", "1", "Admin", "Admin" }
                });
        }
    }
}
