using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskListSuper2021.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98f3a634-70c1-4e75-a5d0-9fe86602c271", "7253a80b-a4ca-4f1c-99f4-bf6d0e5abc56", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75a7ef87-2142-4a35-9f9f-eaea3f77c419", 0, "45435cf7-aee1-4391-8b16-7403bd4073a8", "michal.stehlik@pslib.cz", true, false, null, "MICHAL.STEHLIK@PSLIB.CZ", "MICHAL.STEHLIK@PSLIB.CZ", "AQAAAAEAACcQAAAAEO7TnUZQA96ONq04t/r3DjUBsqp0gHgocsKIzV0TkwJHB0tpsVQ4w6waIzK94gAIuQ==", null, false, "", false, "michal.stehlik@pslib.cz" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "98f3a634-70c1-4e75-a5d0-9fe86602c271", "75a7ef87-2142-4a35-9f9f-eaea3f77c419" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98f3a634-70c1-4e75-a5d0-9fe86602c271", "75a7ef87-2142-4a35-9f9f-eaea3f77c419" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f3a634-70c1-4e75-a5d0-9fe86602c271");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a7ef87-2142-4a35-9f9f-eaea3f77c419");
        }
    }
}
