using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class maitenancemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    equipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    damageTYpe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    deptManagId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    itId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ControllerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmangconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmangconfirmStatus = table.Column<bool>(type: "bit", nullable: true),
                    Departmang_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ITconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    IT_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PU = table.Column<float>(type: "real", nullable: true),
                    GL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PR_Status = table.Column<bool>(type: "bit", nullable: true),
                    PR_Not_ConfirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ControllerconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    Controller_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_AspNetUsers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_AspNetUsers_deptManagId",
                        column: x => x.deptManagId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_AspNetUsers_itId",
                        column: x => x.itId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SuplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ControllerId",
                table: "MaintenanceRequests",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_deptManagId",
                table: "MaintenanceRequests",
                column: "deptManagId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_itId",
                table: "MaintenanceRequests",
                column: "itId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_supplierId",
                table: "MaintenanceRequests",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_UserId",
                table: "MaintenanceRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRequests");
        }
    }
}
