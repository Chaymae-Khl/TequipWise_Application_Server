using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class usermanager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002b76aa-50ce-4378-9456-e586b83352d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0165b82a-5d62-411f-bdfb-8f2fce6fa066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e94e1b0-18ae-43ea-91bb-686e79ad7d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "863b5e64-15ed-4f08-93e5-5aac04f78c06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8932e5e4-f614-4941-af3e-05aa83bd5269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c72976-2829-436a-9d0a-b9487a58519f");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "223f1665-8722-4242-a67f-86751efee067", "2", "User", "User" },
                    { "765e92ab-3fae-45c1-99f7-8b168661a103", "5", "FinanceManager", "FinanceManager" },
                    { "a8197a5b-eb3e-4105-b4a6-1da9015fb47e", "1", "Admin", "Admin" },
                    { "ba5a2412-7e7a-468e-ac41-df379327c620", "4", "HrManager", "HrManager" },
                    { "c4cc29f7-6c6b-4522-b981-42a48257f7ac", "3", "DeptManager", "DeptManager" },
                    { "fc2c06eb-871b-41cc-8783-a168a7116f95", "5", "FinanceManager", "ItAnalyst" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "223f1665-8722-4242-a67f-86751efee067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "765e92ab-3fae-45c1-99f7-8b168661a103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8197a5b-eb3e-4105-b4a6-1da9015fb47e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba5a2412-7e7a-468e-ac41-df379327c620");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4cc29f7-6c6b-4522-b981-42a48257f7ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc2c06eb-871b-41cc-8783-a168a7116f95");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "002b76aa-50ce-4378-9456-e586b83352d9", "3", "DeptManager", "DeptManager" },
                    { "0165b82a-5d62-411f-bdfb-8f2fce6fa066", "2", "User", "User" },
                    { "7e94e1b0-18ae-43ea-91bb-686e79ad7d91", "1", "Admin", "Admin" },
                    { "863b5e64-15ed-4f08-93e5-5aac04f78c06", "5", "FinanceManager", "FinanceManager" },
                    { "8932e5e4-f614-4941-af3e-05aa83bd5269", "4", "HrManager", "HrManager" },
                    { "d7c72976-2829-436a-9d0a-b9487a58519f", "5", "FinanceManager", "ItAnalyst" }
                });
        }
    }
}
