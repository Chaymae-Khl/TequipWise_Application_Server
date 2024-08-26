using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newhireEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewHireEmail",
                table: "PhoneRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewHireEmail",
                table: "EquipmentRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewHireEmail",
                table: "PhoneRequests");

            migrationBuilder.DropColumn(
                name: "NewHireEmail",
                table: "EquipmentRequests");
        }
    }
}
