using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "427e995b-b4e3-486a-b5e6-26c420b1b89d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6884d8a5-5657-4175-80ef-50e07a8c5989");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8daf90-c8dd-4601-a27c-ca148119fc77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eaf201f-7dbc-4a7c-9b26-11f15aa6942a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7215bac3-859e-43c4-a26f-3e3ab06b5bdc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f307ee7-5566-4dc7-a98c-3e7f526e1044", "7", "Approver", "Approver" },
                    { "446541c0-abc9-4e0c-aa95-1da114a92ad8", "2", "User", "User" },
                    { "44f4e7f6-99ea-4ab6-accb-94def11668dd", "4", "It Approver", "It Approver" },
                    { "4c638833-37cd-45f3-bf43-92ae77e1df82", "1", "Admin", "Admin" },
                    { "86c8ce0c-1b17-4716-95d6-4160b0edc388", "5", "Controller", "Controller" },
                    { "eb00318e-85a6-42b7-872b-c175bc62b1ad", "6", "BackupApprover", "BackupApprover" },
                    { "ed52572e-83ce-4841-8a49-3090368c6a8e", "3", "Manager", "Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f307ee7-5566-4dc7-a98c-3e7f526e1044");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "446541c0-abc9-4e0c-aa95-1da114a92ad8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44f4e7f6-99ea-4ab6-accb-94def11668dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c638833-37cd-45f3-bf43-92ae77e1df82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c8ce0c-1b17-4716-95d6-4160b0edc388");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb00318e-85a6-42b7-872b-c175bc62b1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed52572e-83ce-4841-8a49-3090368c6a8e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "427e995b-b4e3-486a-b5e6-26c420b1b89d", "5", "Controller", "Controller" },
                    { "6884d8a5-5657-4175-80ef-50e07a8c5989", "4", "It Approver", "It Approver" },
                    { "6e8daf90-c8dd-4601-a27c-ca148119fc77", "3", "Manager", "Manager" },
                    { "6eaf201f-7dbc-4a7c-9b26-11f15aa6942a", "2", "User", "User" },
                    { "7215bac3-859e-43c4-a26f-3e3ab06b5bdc", "1", "Admin", "Admin" }
                });
        }
    }
}
