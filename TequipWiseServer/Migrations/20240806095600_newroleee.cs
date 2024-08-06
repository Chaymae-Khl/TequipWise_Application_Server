using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class newroleee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "Suppliers",
                columns: table => new
                {
                    SuplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    suuplier_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SuplierId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipementSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierrid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipementSN);
                    table.ForeignKey(
                        name: "FK_Equipments_Suppliers_supplierrid",
                        column: x => x.supplierrid,
                        principalTable: "Suppliers",
                        principalColumn: "SuplierId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    TeNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusBackupProvider = table.Column<bool>(type: "bit", nullable: true),
                    backupActive = table.Column<bool>(type: "bit", nullable: true),
                    BackupaproverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApproverActive = table.Column<bool>(type: "bit", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    locaId = table.Column<int>(type: "int", nullable: true),
                    DepartmentDeptId = table.Column<int>(type: "int", nullable: true),
                    plantId = table.Column<int>(type: "int", nullable: true),
                    SapNumberId = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_BackupaproverId",
                        column: x => x.BackupaproverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Location_locaId",
                        column: x => x.locaId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailManger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentRequests",
                columns: table => new
                {
                    EquipmentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<float>(type: "real", nullable: true),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: true),
                    ForWho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewHireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Plants",
                columns: table => new
                {
                    PlantNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plant_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ITApproverId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantNumber);
                    table.ForeignKey(
                        name: "FK_Plants_AspNetUsers_ITApproverId",
                        column: x => x.ITApproverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SapNumbers",
                columns: table => new
                {
                    SApID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SapNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idcontroller = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapNumbers", x => x.SApID);
                    table.ForeignKey(
                        name: "FK_SapNumbers_AspNetUsers_Idcontroller",
                        column: x => x.Idcontroller,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocationDepartments",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDepartments", x => new { x.LocationId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_LocationDepartments_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "subEquipmentRequests",
                columns: table => new
                {
                    SubEquipmentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PU = table.Column<float>(type: "real", nullable: true),
                    GL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PR_Status = table.Column<bool>(type: "bit", nullable: true),
                    PR_Not_ConfirmCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    AssetReceiveByEMployeAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceptionStatus = table.Column<bool>(type: "bit", nullable: true),
                    AssetSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetModele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    supplierrid = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_subEquipmentRequests_Suppliers_supplierrid",
                        column: x => x.supplierrid,
                        principalTable: "Suppliers",
                        principalColumn: "SuplierId");
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
                    { "104c3de1-4cfe-42ee-b516-0d14231263c4", "8", "ControllerBackupApprover", "ControllerBackupApprover" },
                    { "23d33fbe-5735-46ac-a47b-aa8c1e466005", "3", "Manager", "Manager" },
                    { "747bb8d4-ad7c-4e31-8910-ee4794112c83", "6", "ManagerBackupApprover", "ManagerBackupApprover" },
                    { "8cf40d46-7051-4a6b-989e-954dbcb8b9b9", "1", "Admin", "Admin" },
                    { "8d81fce2-616a-49d5-b79f-d72d72a484c8", "2", "User", "User" },
                    { "9af6a271-c102-4af1-8b91-0a1551a06566", "5", "Controller", "Controller" },
                    { "a2c7c398-732b-4592-be93-0561eba43bbf", "9", "Approver", "Approver" },
                    { "c7db5522-8f44-43c7-ae50-1f9a01a5c0f6", "4", "It Approver", "It Approver" },
                    { "dde75b13-2c74-4bf7-849a-66f22aa1131f", "7", "ItBackupApprover", "ItBackupApprover" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BackupaproverId",
                table: "AspNetUsers",
                column: "BackupaproverId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_locaId",
                table: "AspNetUsers",
                column: "locaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_plantId",
                table: "AspNetUsers",
                column: "plantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SapNumberId",
                table: "AspNetUsers",
                column: "SapNumberId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRequests_UserId",
                table: "EquipmentRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_supplierrid",
                table: "Equipments",
                column: "supplierrid");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDepartments_DepartmentId",
                table: "LocationDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDepartments_ManagerId",
                table: "LocationDepartments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationPlants_PlantId",
                table: "LocationPlants",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ITApproverId",
                table: "Plants",
                column: "ITApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_SapNumbers_Idcontroller",
                table: "SapNumbers",
                column: "Idcontroller");

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

            migrationBuilder.CreateIndex(
                name: "IX_subEquipmentRequests_supplierrid",
                table: "subEquipmentRequests",
                column: "supplierrid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentDeptId",
                table: "AspNetUsers",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Plants_plantId",
                table: "AspNetUsers",
                column: "plantId",
                principalTable: "Plants",
                principalColumn: "PlantNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SapNumbers_SapNumberId",
                table: "AspNetUsers",
                column: "SapNumberId",
                principalTable: "SapNumbers",
                principalColumn: "SApID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_ITApproverId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_SapNumbers_AspNetUsers_Idcontroller",
                table: "SapNumbers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LocationDepartments");

            migrationBuilder.DropTable(
                name: "LocationPlants");

            migrationBuilder.DropTable(
                name: "subEquipmentRequests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EquipmentRequests");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "SapNumbers");
        }
    }
}
