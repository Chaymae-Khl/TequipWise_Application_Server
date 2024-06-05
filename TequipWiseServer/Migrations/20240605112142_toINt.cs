using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class toINt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipementSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipementSN);
                    table.ForeignKey(
                        name: "FK_Equipments_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SuplierId");
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SupplierId",
                table: "Equipments",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6841f2ee-24f9-4a39-9da4-ee433b5c9c38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcecfef-db33-40af-9d07-0ee33fa45e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82b4a9a0-2b04-4671-a5f3-784190d35923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92819e02-0924-4db4-b6eb-34f7695cc196");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7b5d9b1-329e-49f0-af6f-e46028301dca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc0bd085-24a6-4215-b39f-1b5d4d261689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed6a3fd-5ea4-41dc-9c47-5d0a22d88d03");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "079fab96-630a-43dd-82e5-7fb391359ad8", "6", "ItAnalyst", "ItAnalyst" },
                    { "24874f6d-5668-466c-9685-9ce1f2be1661", "3", "DeptManager", "DeptManager" },
                    { "4eb6938c-81bb-4b87-967e-58d8ccf4cb27", "4", "HrManager", "HrManager" },
                    { "aa8fa98b-f3e3-453e-88cc-98d74f367948", "1", "Admin", "Admin" },
                    { "b603a1bf-6892-494e-a7fa-bdc0b368ef87", "5", "FinanceManager", "FinanceManager" },
                    { "dfc55ae9-02be-4c46-a3e3-a00155645b56", "2", "User", "User" },
                    { "f5b69d67-98bf-4ec2-829d-e9e35af882e5", "7", "Controller", "Controller" }
                });
        }
    }
}
