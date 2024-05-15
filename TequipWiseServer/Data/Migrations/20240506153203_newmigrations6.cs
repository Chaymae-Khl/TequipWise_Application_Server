using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigrations6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5821ae5a-61f0-49ca-be5c-5bbfd2efe33e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfb7a96-3c16-4d3c-8f20-bceb1f4fd9e5");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7decf03f-29c5-4ef8-9d4c-1265e5a478ec", "2", "User", "User" },
                    { "9320699e-6173-4552-8eb3-192d034ac591", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7decf03f-29c5-4ef8-9d4c-1265e5a478ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9320699e-6173-4552-8eb3-192d034ac591");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5821ae5a-61f0-49ca-be5c-5bbfd2efe33e", "2", "User", "User" },
                    { "7cfb7a96-3c16-4d3c-8f20-bceb1f4fd9e5", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantNumber");
        }
    }
}
