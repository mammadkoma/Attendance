using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance.Server.data.migrations
{
    public partial class notmapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9e9b3878-6c8c-40cf-a7c1-58f2ea499a7a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "78a520f2-d0d4-4a1e-a60d-f5a0f07a67c8");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d2c3c94-cac3-44ef-924e-abd60722a633", "AQAAAAEAACcQAAAAEOoKDKSkjDj1ElQAkFzFtdaEEtchVeT/Jl3I13ggZxJLSAS6XvLLhbpckDEvI0LTVA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b8603241-f1f8-4a95-9bd9-03059ab2b9de");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2885109b-c384-41ac-adaf-4a6357a0e5b7");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b5fe217-7205-44c9-b705-be680afe9171", "AQAAAAEAACcQAAAAEC2UYe2WTV3nuWtlpy18HM4Su3UwMTRESchHf/kEzI+mUzgYJHbB8ig+7JayAJZPDA==" });
        }
    }
}
