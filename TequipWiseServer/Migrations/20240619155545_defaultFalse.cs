using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class defaultFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38795a32-a6fc-4dad-9d4d-fbb9d352bca5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65fdfa17-8a7b-4ebd-8a7b-c4fadca2a1b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97e5aed1-86dc-4356-8b6c-a175ec958dbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eb14dec-3d7b-4486-9cd3-1d7363b58ab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e44cd447-16ae-4468-bb84-1d240dd6311b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "093becdb-559d-4bfd-a592-54d5521028c7", "5", "Controller", "Controller" },
                    { "602002ac-5a59-4bb7-88ce-cf615f8ce80f", "4", "ItAnalyst", "ItAnalyst" },
                    { "68f8f47c-c441-4066-bea2-640d89d92c1c", "1", "Admin", "Admin" },
                    { "99dae035-343a-4d47-bd12-87f44a61cdd5", "3", "DeptManager", "DeptManager" },
                    { "b259a0a0-03f1-4a5a-bdbe-b2d0dba1f7e2", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "093becdb-559d-4bfd-a592-54d5521028c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "602002ac-5a59-4bb7-88ce-cf615f8ce80f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68f8f47c-c441-4066-bea2-640d89d92c1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99dae035-343a-4d47-bd12-87f44a61cdd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b259a0a0-03f1-4a5a-bdbe-b2d0dba1f7e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38795a32-a6fc-4dad-9d4d-fbb9d352bca5", "1", "Admin", "Admin" },
                    { "65fdfa17-8a7b-4ebd-8a7b-c4fadca2a1b3", "3", "DeptManager", "DeptManager" },
                    { "97e5aed1-86dc-4356-8b6c-a175ec958dbf", "4", "ItAnalyst", "ItAnalyst" },
                    { "9eb14dec-3d7b-4486-9cd3-1d7363b58ab1", "2", "User", "User" },
                    { "e44cd447-16ae-4468-bb84-1d240dd6311b", "5", "Controller", "Controller" }
                });
        }
    }
}
