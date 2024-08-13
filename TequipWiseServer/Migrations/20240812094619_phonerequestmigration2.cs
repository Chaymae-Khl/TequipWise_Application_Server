using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class phonerequestmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRequest_AspNetUsers_UserId",
                table: "EquipmentRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId1",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId2",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_HRId",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_UserId",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_deptManagId",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_itId",
                table: "PhoneRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequest_RequestId",
                table: "subEquipmentRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneRequest",
                table: "PhoneRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentRequest",
                table: "EquipmentRequest");

            migrationBuilder.RenameTable(
                name: "PhoneRequest",
                newName: "PhoneRequests");

            migrationBuilder.RenameTable(
                name: "EquipmentRequest",
                newName: "EquipmentRequests");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_UserId",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_itId",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_itId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_HRId",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_HRId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_deptManagId",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_deptManagId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_ApplicationUserId2",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_ApplicationUserId2");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_ApplicationUserId1",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequest_ApplicationUserId",
                table: "PhoneRequests",
                newName: "IX_PhoneRequests_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentRequest_UserId",
                table: "EquipmentRequests",
                newName: "IX_EquipmentRequests_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneRequests",
                table: "PhoneRequests",
                column: "PhoneRequestId");

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
                name: "FK_PhoneRequests_AspNetUsers_ApplicationUserId",
                table: "PhoneRequests",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_ApplicationUserId1",
                table: "PhoneRequests",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_ApplicationUserId2",
                table: "PhoneRequests",
                column: "ApplicationUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_HRId",
                table: "PhoneRequests",
                column: "HRId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_UserId",
                table: "PhoneRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_deptManagId",
                table: "PhoneRequests",
                column: "deptManagId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_itId",
                table: "PhoneRequests",
                column: "itId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequests_RequestId",
                table: "subEquipmentRequests",
                column: "RequestId",
                principalTable: "EquipmentRequests",
                principalColumn: "EquipmentRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRequests_AspNetUsers_UserId",
                table: "EquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_ApplicationUserId",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_ApplicationUserId1",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_ApplicationUserId2",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_HRId",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_UserId",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_deptManagId",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneRequests_AspNetUsers_itId",
                table: "PhoneRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequests_RequestId",
                table: "subEquipmentRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneRequests",
                table: "PhoneRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentRequests",
                table: "EquipmentRequests");

            migrationBuilder.RenameTable(
                name: "PhoneRequests",
                newName: "PhoneRequest");

            migrationBuilder.RenameTable(
                name: "EquipmentRequests",
                newName: "EquipmentRequest");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_UserId",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_itId",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_itId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_HRId",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_HRId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_deptManagId",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_deptManagId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_ApplicationUserId2",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_ApplicationUserId2");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_ApplicationUserId1",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneRequests_ApplicationUserId",
                table: "PhoneRequest",
                newName: "IX_PhoneRequest_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentRequests_UserId",
                table: "EquipmentRequest",
                newName: "IX_EquipmentRequest_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneRequest",
                table: "PhoneRequest",
                column: "PhoneRequestId");

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
                name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId",
                table: "PhoneRequest",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId1",
                table: "PhoneRequest",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId2",
                table: "PhoneRequest",
                column: "ApplicationUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_HRId",
                table: "PhoneRequest",
                column: "HRId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_UserId",
                table: "PhoneRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_deptManagId",
                table: "PhoneRequest",
                column: "deptManagId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneRequest_AspNetUsers_itId",
                table: "PhoneRequest",
                column: "itId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subEquipmentRequests_EquipmentRequest_RequestId",
                table: "subEquipmentRequests",
                column: "RequestId",
                principalTable: "EquipmentRequest",
                principalColumn: "EquipmentRequestId");
        }
    }
}
