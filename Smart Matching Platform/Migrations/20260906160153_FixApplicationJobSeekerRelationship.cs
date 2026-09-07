using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRecruitmentMatchingPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationJobSeekerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_JobSeekerId_VacancyId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "JobSeekerId",
                table: "Applications");

            migrationBuilder.AddColumn<Guid>(
                name: "JobSeekerProfileId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobSeekerProfileId_VacancyId",
                table: "Applications",
                columns: new[] { "JobSeekerProfileId", "VacancyId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications",
                column: "JobSeekerProfileId",
                principalTable: "JobSeekerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobSeekerProfileId_VacancyId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "JobSeekerProfileId",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "JobSeekerId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobSeekerId_VacancyId",
                table: "Applications",
                columns: new[] { "JobSeekerId", "VacancyId" },
                unique: true);
        }
    }
}
