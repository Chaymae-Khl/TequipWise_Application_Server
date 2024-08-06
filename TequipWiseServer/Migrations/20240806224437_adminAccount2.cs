using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequipWiseServer.Migrations
{
    /// <inheritdoc />
    public partial class adminAccount2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a6e0a652-4849-4f58-b610-c6cc7914d741", 0, "7696932d-6bc2-4054-a893-294e212d4278", "IdentityUser", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEJRmBF1deae6yGxHPwFJgap+1CcgvtMRECex59LLstuBsAa01mgLyO5vpB64uR+gRg==", null, false, "6ec603de-d4b4-4af4-81aa-2b3706038c13", false, "TE-Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6e0a652-4849-4f58-b610-c6cc7914d741");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "480d512f-a09a-46dd-9b1a-a1fb52f21b42", "IdentityUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIb3rkG2Iq+Y7wotKLW9WqzOTjYB8B/9+gf77AZ0jvoCM1Bn369i2YMIhuPBFUwr4w==", null, false, "", false, "admin@admin.com" });
        }
    }
}
