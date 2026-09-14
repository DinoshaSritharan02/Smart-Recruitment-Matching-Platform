using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRecruitmentMatchingPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class TestEmployerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Employers_EmployerId",
                table: "Vacancies",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Employers_EmployerId",
                table: "Vacancies");
        }
    }
}
