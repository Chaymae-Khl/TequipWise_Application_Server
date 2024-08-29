using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class subrequestemailussr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewHireEmail",
                table: "EquipmentRequests");

            migrationBuilder.AddColumn<string>(
                name: "NewHireEmail",
                table: "subEquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewHireEmail",
                table: "subEquipmentRequests");

            migrationBuilder.AddColumn<string>(
                name: "NewHireEmail",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
