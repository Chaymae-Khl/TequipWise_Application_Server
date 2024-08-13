using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class phonerequestmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneRequest",
                columns: table => new
                {
                    PhoneRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    ForWho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewHireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneRequestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacemnetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    deptManagId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    itId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HRId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmangconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmangconfirmStatus = table.Column<bool>(type: "bit", nullable: true),
                    Departmang_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ITconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    IT_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetReceiveByEMployeAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceptionStatus = table.Column<bool>(type: "bit", nullable: true),
                    HRconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    HR_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneRequest", x => x.PhoneRequestId);
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_ApplicationUserId2",
                        column: x => x.ApplicationUserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_HRId",
                        column: x => x.HRId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_deptManagId",
                        column: x => x.deptManagId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneRequest_AspNetUsers_itId",
                        column: x => x.itId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_ApplicationUserId",
                table: "PhoneRequest",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_ApplicationUserId1",
                table: "PhoneRequest",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_ApplicationUserId2",
                table: "PhoneRequest",
                column: "ApplicationUserId2");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_deptManagId",
                table: "PhoneRequest",
                column: "deptManagId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_HRId",
                table: "PhoneRequest",
                column: "HRId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_itId",
                table: "PhoneRequest",
                column: "itId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneRequest_UserId",
                table: "PhoneRequest",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneRequest");
        }
    }
}
