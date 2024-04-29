using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webbutvecklinglabb2Heimbrand.Client.AuthApi.Migrations
{
    /// <inheritdoc />
    public partial class inittt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cbc70e5-04d3-4864-8711-140e0b37de67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93967608-2589-44db-9aa2-84eca81543c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23e580f6-398d-4c82-8676-3bb1631b09af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65b38c48-a3a4-4b80-a863-81eaf9c589d6", null, "User", "USER" },
                    { "747c447d-955d-4b4d-a6c7-1d7bdea5b6c0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "51fb1f58-cdad-41f9-a447-607e1dd4885c", 0, "c6b348a9-7698-486e-94f1-65bdc60fe7a9", "admin.admin@admin.se", true, false, null, "ADMIN.ADMIN@ADMIN.SE", "ADMIN.ADMIN@ADMIN.SE", "AQAAAAIAAYagAAAAEBCV6hlK6VivvC/4L6ojUax1cD1NlSskQkDDIoT+/pX+ueBWeZXXCI5jAzH9cGH1Hw==", null, false, "253b6800-1dc9-4ac5-ade0-9b09de55c4aa", false, "admin.admin@admin.se" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65b38c48-a3a4-4b80-a863-81eaf9c589d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "747c447d-955d-4b4d-a6c7-1d7bdea5b6c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51fb1f58-cdad-41f9-a447-607e1dd4885c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5cbc70e5-04d3-4864-8711-140e0b37de67", null, "User", "USER" },
                    { "93967608-2589-44db-9aa2-84eca81543c5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23e580f6-398d-4c82-8676-3bb1631b09af", 0, "d0474914-dd8f-40a6-b994-31f7a0a7d64f", "admin.admin@admin.se", true, false, null, "ADMIN.ADMIN@ADMIN.SE", "ADMIN.ADMIN@ADMIN.SE", "AQAAAAIAAYagAAAAECDvkn2/la/lI8/4nhPQjnS89G9ACKjuOVaVQgs/YRLlt3dPnugNwy7uudndusShdQ==", null, false, "b1cee6d3-be63-4666-833b-ffbe67b31b73", false, "admin.admin@admin.se" });
        }
    }
}
