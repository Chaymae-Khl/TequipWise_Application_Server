using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class adminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07dc44a0-1c86-4768-964f-e75803046750");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8edbe0-5762-4569-bc5e-99e483deff47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c25c134-75dd-42d9-a7e1-1fd1e21f4446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b3fd1a8-1d0b-4bf1-853f-13917ba55793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ade7591-00fd-41b1-89b6-987d66a3fcae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82748eb6-957f-4855-8af0-09f78fd72dce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a47a643-00c0-4805-b099-75a4a85f5166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d13e1ebb-3bf4-40b7-ab72-b97aaeac3101");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef5151dd-3e5a-47e4-9cca-24dc365ee4b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "Admin", "ADMIN" },
                    { "2", "2", "User", "USER" },
                    { "3", "3", "Manager", "MANAGER" },
                    { "4", "4", "It Approver", "IT APPROVER" },
                    { "5", "5", "Controller", "CONTROLLER" },
                    { "6", "6", "ManagerBackupApprover", "MANAGERBACKUPAPPROVER" },
                    { "7", "7", "ItBackupApprover", "ITBACKUPAPPROVER" },
                    { "8", "8", "ControllerBackupApprover", "CONTROLLERBACKUPAPPROVER" },
                    { "9", "9", "Approver", "APPROVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "480d512f-a09a-46dd-9b1a-a1fb52f21b42", "IdentityUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIb3rkG2Iq+Y7wotKLW9WqzOTjYB8B/9+gf77AZ0jvoCM1Bn369i2YMIhuPBFUwr4w==", null, false, "", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07dc44a0-1c86-4768-964f-e75803046750", "9", "Approver", "Approver" },
                    { "1b8edbe0-5762-4569-bc5e-99e483deff47", "5", "Controller", "Controller" },
                    { "3c25c134-75dd-42d9-a7e1-1fd1e21f4446", "2", "User", "User" },
                    { "6b3fd1a8-1d0b-4bf1-853f-13917ba55793", "6", "ManagerBackupApprover", "ManagerBackupApprover" },
                    { "7ade7591-00fd-41b1-89b6-987d66a3fcae", "1", "Admin", "Admin" },
                    { "82748eb6-957f-4855-8af0-09f78fd72dce", "3", "Manager", "Manager" },
                    { "9a47a643-00c0-4805-b099-75a4a85f5166", "8", "ControllerBackupApprover", "ControllerBackupApprover" },
                    { "d13e1ebb-3bf4-40b7-ab72-b97aaeac3101", "7", "ItBackupApprover", "ItBackupApprover" },
                    { "ef5151dd-3e5a-47e4-9cca-24dc365ee4b7", "4", "It Approver", "It Approver" }
                });
        }
    }
}
