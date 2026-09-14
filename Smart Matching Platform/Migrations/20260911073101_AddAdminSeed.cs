using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRecruitmentMatchingPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "Role" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@smart.com", "System", true, "Administrator", "$2a$11$yWvW0HzFhvyILDAzvjMQdeUNktcrEWltq4ZIFQkFVAaR5FjIhERLC", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
