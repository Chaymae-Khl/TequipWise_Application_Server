using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Newmigartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2861abb9-c4af-4364-b37e-3f1ee867d45e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "290b3512-87cf-42ce-9faa-65f25f537d87");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1645ae83-6dfe-4c56-b608-c5bbf555b1f5", "2", "User", "User" },
                    { "2b1e5183-cb1c-439a-8da3-3b97e8da43ab", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1645ae83-6dfe-4c56-b608-c5bbf555b1f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b1e5183-cb1c-439a-8da3-3b97e8da43ab");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2861abb9-c4af-4364-b37e-3f1ee867d45e", "2", "User", "User" },
                    { "290b3512-87cf-42ce-9faa-65f25f537d87", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
