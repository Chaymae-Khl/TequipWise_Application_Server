using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class migartionchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Plants_PlantId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_PlantId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a3a833b-2526-467d-b604-69f741781028");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdbb2ece-df87-4e9e-ba1c-db899a29e44d");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Departments");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "LocationDepartments",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDepartments", x => new { x.LocationId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_LocationDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationDepartments_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationPlants",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPlants", x => new { x.LocationId, x.PlantId });
                    table.ForeignKey(
                        name: "FK_LocationPlants_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f296e9c-0f3c-456c-9c7e-335b6285acb9", "2", "User", "User" },
                    { "7ad889fa-b775-4d8d-95fb-d320d3a5fa43", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationDepartments_DepartmentId",
                table: "LocationDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationPlants_PlantId",
                table: "LocationPlants",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationDepartments");

            migrationBuilder.DropTable(
                name: "LocationPlants");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f296e9c-0f3c-456c-9c7e-335b6285acb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ad889fa-b775-4d8d-95fb-d320d3a5fa43");

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a3a833b-2526-467d-b604-69f741781028", "1", "Admin", "Admin" },
                    { "cdbb2ece-df87-4e9e-ba1c-db899a29e44d", "2", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_PlantId",
                table: "Departments",
                column: "PlantId");

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
