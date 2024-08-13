using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class phonerequestmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRequests_AspNetUsers_UserId",
                table: "EquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequests_RequestId",
                table: "subEquipmentRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentRequests",
                table: "EquipmentRequests");

            migrationBuilder.RenameTable(
                name: "EquipmentRequests",
                newName: "EquipmentRequest");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentRequests_UserId",
                table: "EquipmentRequest",
                newName: "IX_EquipmentRequest_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentRequest",
                table: "EquipmentRequest",
                column: "EquipmentRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRequest_AspNetUsers_UserId",
                table: "EquipmentRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequest_RequestId",
                table: "subEquipmentRequests",
                column: "RequestId",
                principalTable: "EquipmentRequest",
                principalColumn: "EquipmentRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRequest_AspNetUsers_UserId",
                table: "EquipmentRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequest_RequestId",
                table: "subEquipmentRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentRequest",
                table: "EquipmentRequest");

            migrationBuilder.RenameTable(
                name: "EquipmentRequest",
                newName: "EquipmentRequests");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentRequest_UserId",
                table: "EquipmentRequests",
                newName: "IX_EquipmentRequests_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentRequests",
                table: "EquipmentRequests",
                column: "EquipmentRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRequests_AspNetUsers_UserId",
                table: "EquipmentRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequests_RequestId",
                table: "subEquipmentRequests",
                column: "RequestId",
                principalTable: "EquipmentRequests",
                principalColumn: "EquipmentRequestId");
        }
    }
}
