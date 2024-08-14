using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class hrapproveradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HRApproverId",
                table: "Plants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_HRApproverId",
                table: "Plants",
                column: "HRApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_HRApproverId",
                table: "Plants",
                column: "HRApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_HRApproverId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_HRApproverId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "HRApproverId",
                table: "Plants");
        }
    }
}
