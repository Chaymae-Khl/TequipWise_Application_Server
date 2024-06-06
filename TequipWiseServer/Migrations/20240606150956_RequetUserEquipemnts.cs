using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class RequetUserEquipemnts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32a7c8ff-748c-41db-905d-2e75e94c46f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "515a150b-e964-4794-b82e-3bf6a5898c65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ec91ab8-a9c8-4a90-bb8c-687680144178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e5a72fe-3489-4991-abc8-6d0b7f0369fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a46c358a-77d9-49b7-b71a-9c8df6dfe122");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fca5e0-1dbf-4cc6-8f23-1b81a1720f26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5f0593-8c66-4b6c-83b6-6f907f32d1c0");

            migrationBuilder.CreateTable(
                name: "UserEquipmentRequests",
                columns: table => new
                {
                    UserEquipmentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    NewhireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberEquipment = table.Column<int>(type: "int", nullable: true),
                    DepartmangconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmangconfirmStatus = table.Column<bool>(type: "bit", nullable: true),
                    Departmang_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanceconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinanceconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    Finance_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITconfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ITconfirmSatuts = table.Column<bool>(type: "bit", nullable: true),
                    IT_Not_confirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEquipmentRequests", x => x.UserEquipmentRequestId);
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEquipmentRequests_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipementSN",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_EquipmentId",
                table: "UserEquipmentRequests",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEquipmentRequests_UserId",
                table: "UserEquipmentRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEquipmentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "247cddb8-f622-4eed-afcb-30c723a04ce9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51a45d16-76b7-4627-9fb3-6a5b2a31cccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73013f03-d19b-40d3-a2cf-f1e2d42fc73d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7593f447-cd0e-4b5a-bbd9-50901dcf27b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d90897d-fddc-4db5-aa52-e81c5b699f11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6f7e0b-f2b1-4e4d-9c50-3ab441c2af59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebbef6a5-45f6-432f-9538-27a732a5e0a0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32a7c8ff-748c-41db-905d-2e75e94c46f5", "7", "Controller", "Controller" },
                    { "515a150b-e964-4794-b82e-3bf6a5898c65", "2", "User", "User" },
                    { "5ec91ab8-a9c8-4a90-bb8c-687680144178", "1", "Admin", "Admin" },
                    { "9e5a72fe-3489-4991-abc8-6d0b7f0369fe", "4", "HrManager", "HrManager" },
                    { "a46c358a-77d9-49b7-b71a-9c8df6dfe122", "3", "DeptManager", "DeptManager" },
                    { "c5fca5e0-1dbf-4cc6-8f23-1b81a1720f26", "6", "ItAnalyst", "ItAnalyst" },
                    { "ed5f0593-8c66-4b6c-83b6-6f907f32d1c0", "5", "FinanceManager", "FinanceManager" }
                });
        }
    }
}
