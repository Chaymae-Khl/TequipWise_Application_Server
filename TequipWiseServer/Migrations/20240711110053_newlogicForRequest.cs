using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newlogicForRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2169f318-baca-4cc3-bf19-3facc2181229");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65a7cc43-7fd3-4fb9-8334-c486c79b6ff6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a520efa-3f0a-46ac-81d9-232e830b6d8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4329b69-a807-4351-a710-ef61c7716864");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db816a9c-5a5a-45a9-b187-29522d244503");

            migrationBuilder.CreateTable(
                name: "EquipmentRequests",
                columns: table => new
                {
                    EquipmentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: true),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    isNewhire = table.Column<bool>(type: "bit", nullable: true),
                    NewHireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PR_Status = table.Column<bool>(type: "bit", nullable: true),
                    PR_Not_ConfirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRequests", x => x.EquipmentRequestId);
                    table.ForeignKey(
                        name: "FK_EquipmentRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "subEquipmentRequests",
                columns: table => new
                {
                    SubEquipmentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PU = table.Column<float>(type: "real", nullable: true),
                    Totale = table.Column<float>(type: "real", nullable: false),
                    deptManagId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    itId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    controllerid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubRequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    QtEquipment = table.Column<int>(type: "int", nullable: true),
                    DepartmangconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmangconfirmStatus = table.Column<bool>(type: "bit", nullable: true),
                    Departmang_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanceconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinanceconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    Finance_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ITconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    IT_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subEquipmentRequests", x => x.SubEquipmentRequestId);
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_AspNetUsers_ApplicationUserId2",
                        column: x => x.ApplicationUserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_AspNetUsers_controllerid",
                        column: x => x.controllerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_AspNetUsers_deptManagId",
                        column: x => x.deptManagId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_AspNetUsers_itId",
                        column: x => x.itId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_EquipmentRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "EquipmentRequests",
                        principalColumn: "EquipmentRequestId");
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipementSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cd082a2-a816-46b7-80fd-534ef8c4f28d", "2", "User", "User" },
                    { "4533950b-2de5-4c8e-987d-f8458c82f0b0", "4", "It Approver", "It Approver" },
                    { "832c6675-291f-44bd-9c46-69adb8ab41af", "5", "Controller", "Controller" },
                    { "90cb1ee9-f67b-4659-b91e-5d68979889fe", "1", "Admin", "Admin" },
                    { "d6eab4f9-2293-4d1c-83d9-538677e7cc68", "3", "Manager", "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRequests_UserId",
                table: "EquipmentRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_ApplicationUserId",
                table: "subEquipmentRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_ApplicationUserId1",
                table: "subEquipmentRequests",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_ApplicationUserId2",
                table: "subEquipmentRequests",
                column: "ApplicationUserId2");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_controllerid",
                table: "subEquipmentRequests",
                column: "controllerid");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_deptManagId",
                table: "subEquipmentRequests",
                column: "deptManagId");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_EquipmentId",
                table: "subEquipmentRequests",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_itId",
                table: "subEquipmentRequests",
                column: "itId");

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_RequestId",
                table: "subEquipmentRequests",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subEquipmentRequests");

            migrationBuilder.DropTable(
                name: "EquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cd082a2-a816-46b7-80fd-534ef8c4f28d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4533950b-2de5-4c8e-987d-f8458c82f0b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832c6675-291f-44bd-9c46-69adb8ab41af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90cb1ee9-f67b-4659-b91e-5d68979889fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6eab4f9-2293-4d1c-83d9-538677e7cc68");

            migrationBuilder.CreateTable(
                name: "UserEquipmentRequests",
                columns: table => new
                {
                    UserEquipmentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    controllerid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    deptManagId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    itId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departmang_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmangconfirmStatus = table.Column<bool>(type: "bit", nullable: true),
                    DepartmangconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Finance_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanceconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    FinanceconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IT_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    ITconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberEquipment = table.Column<int>(type: "int", nullable: true),
                    PONum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PR_Not_ConfirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PR_Status = table.Column<bool>(type: "bit", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    SupplierOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isNewhire = table.Column<bool>(type: "bit", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEquipmentRequests", x => x.UserEquipmentRequestId);
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_AspNetUsers_controllerid",
                        column: x => x.controllerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_AspNetUsers_deptManagId",
                        column: x => x.deptManagId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_AspNetUsers_itId",
                        column: x => x.itId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipementSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2169f318-baca-4cc3-bf19-3facc2181229", "1", "Admin", "Admin" },
                    { "65a7cc43-7fd3-4fb9-8334-c486c79b6ff6", "4", "It Approver", "It Approver" },
                    { "8a520efa-3f0a-46ac-81d9-232e830b6d8f", "2", "User", "User" },
                    { "d4329b69-a807-4351-a710-ef61c7716864", "5", "Controller", "Controller" },
                    { "db816a9c-5a5a-45a9-b187-29522d244503", "3", "Manager", "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_controllerid",
                table: "UserEquipmentRequests",
                column: "controllerid");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_deptManagId",
                table: "UserEquipmentRequests",
                column: "deptManagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_EquipmentId",
                table: "UserEquipmentRequests",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_itId",
                table: "UserEquipmentRequests",
                column: "itId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_UserId",
                table: "UserEquipmentRequests",
                column: "UserId");
        }
    }
}
