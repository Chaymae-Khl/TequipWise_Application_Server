using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class SomeChangees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35287080-727b-47ed-8296-838a2571d41c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4277baf9-ec06-418d-805c-03828e2087db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61699613-9067-4e0b-ac65-302717a01fe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad3ef6ed-2aed-452b-a573-2921af770deb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af4a25d0-5094-46b6-8ff1-475de5e32cfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d97ce497-4f90-4ef2-91be-4e2d02003f8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6430c08-4644-4bdf-aab3-9b412396794a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32a7c8ff-748c-41db-905d-2e75e94c46f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "515a150b-e964-4794-b82e-3bf6a5898c65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ec91ab8-a9c8-4a90-bb8c-687680144178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e5a72fe-3489-4991-abc8-6d0b7f0369fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a46c358a-77d9-49b7-b71a-9c8df6dfe122");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fca5e0-1dbf-4cc6-8f23-1b81a1720f26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5f0593-8c66-4b6c-83b6-6f907f32d1c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35287080-727b-47ed-8296-838a2571d41c", "7", "Controller", "Controller" },
                    { "4277baf9-ec06-418d-805c-03828e2087db", "4", "HrManager", "HrManager" },
                    { "61699613-9067-4e0b-ac65-302717a01fe9", "5", "FinanceManager", "FinanceManager" },
                    { "ad3ef6ed-2aed-452b-a573-2921af770deb", "2", "User", "User" },
                    { "af4a25d0-5094-46b6-8ff1-475de5e32cfb", "3", "DeptManager", "DeptManager" },
                    { "d97ce497-4f90-4ef2-91be-4e2d02003f8e", "1", "Admin", "Admin" },
                    { "e6430c08-4644-4bdf-aab3-9b412396794a", "6", "ItAnalyst", "ItAnalyst" }
                });
        }
    }
}
