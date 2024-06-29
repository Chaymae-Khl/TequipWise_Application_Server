using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class fixissue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a375319d-e0b6-4f54-810d-f6c6182eb2ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b247fc4f-68e0-4967-9160-3c06cc703c05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a41980-2c7a-43ab-a260-fa45004f8df1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7456689-2b34-4f99-a76d-8fa9040d553d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7fea80-ca99-4615-a3d1-5d50cf5fad80");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01073f74-f057-4184-919b-bfd84c020d96", "1", "Admin", "Admin" },
                    { "13898a98-0adc-413e-a59c-2833537d658c", "5", "Controller", "Controller" },
                    { "5d40aa2b-6355-479c-92f2-585b60552d94", "3", "Manager", "Manager" },
                    { "6b04e077-1ebd-40be-9ef5-669219d8f235", "2", "User", "User" },
                    { "973734c1-05e8-4a23-bb75-fe02f572cc1e", "4", "It Approver", "It Approver" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01073f74-f057-4184-919b-bfd84c020d96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13898a98-0adc-413e-a59c-2833537d658c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d40aa2b-6355-479c-92f2-585b60552d94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b04e077-1ebd-40be-9ef5-669219d8f235");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "973734c1-05e8-4a23-bb75-fe02f572cc1e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a375319d-e0b6-4f54-810d-f6c6182eb2ff", "3", "Manager", "Manager" },
                    { "b247fc4f-68e0-4967-9160-3c06cc703c05", "1", "Admin", "Admin" },
                    { "c5a41980-2c7a-43ab-a260-fa45004f8df1", "2", "User", "User" },
                    { "e7456689-2b34-4f99-a76d-8fa9040d553d", "4", "It Approver", "It Approver" },
                    { "ff7fea80-ca99-4615-a3d1-5d50cf5fad80", "5", "Controller", "Controller" }
                });
        }
    }
}
