using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Data.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.JobSeekerId)
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

            builder.HasIndex(a => new { a.JobSeekerId, a.VacancyId })
                .IsUnique();

            builder.HasOne(a => a.Vacancy)
                .WithMany()
                .HasForeignKey(a => a.VacancyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}