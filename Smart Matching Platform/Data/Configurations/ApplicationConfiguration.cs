using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.JobSeekerProfileId)
    .IsRequired();
            builder.Property(a => a.VacancyId)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired();

            builder.Property(a => a.MatchScore)
                .HasPrecision(5, 2);

            builder.Property(a => a.AppliedAt)
                .IsRequired();

            builder.Property(a => a.UpdatedAt)
                .IsRequired();

            builder.HasIndex(a => new { a.JobSeekerProfileId, a.VacancyId })
     .IsUnique();

            builder.HasOne(a => a.JobSeekerProfile)
    .WithMany()
    .HasForeignKey(a => a.JobSeekerProfileId)
    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Vacancy)
                .WithMany()
                .HasForeignKey(a => a.VacancyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}