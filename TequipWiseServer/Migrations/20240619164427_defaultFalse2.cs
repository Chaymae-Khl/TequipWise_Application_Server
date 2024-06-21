using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class defaultFalse2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0404f9ae-852a-4f38-8f65-cba39b51104b", "5", "Controller", "Controller" },
                    { "1b3930c1-343c-41d1-9705-426a7991985c", "2", "User", "User" },
                    { "21628344-20fd-49e1-847e-632993c5cb0a", "4", "ItAnalyst", "ItAnalyst" },
                    { "95d2693f-41f8-43ed-9600-b5f48079b12e", "1", "Admin", "Admin" },
                    { "f699e2a9-9caa-4009-84d1-4cfe11a125f6", "3", "DeptManager", "DeptManager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0404f9ae-852a-4f38-8f65-cba39b51104b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b3930c1-343c-41d1-9705-426a7991985c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21628344-20fd-49e1-847e-632993c5cb0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95d2693f-41f8-43ed-9600-b5f48079b12e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f699e2a9-9caa-4009-84d1-4cfe11a125f6");

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
    }
}
