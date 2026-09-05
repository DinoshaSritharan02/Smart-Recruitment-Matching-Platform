using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Data.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.EmployerId)
                .IsRequired();

            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(v => v.Description)
                .HasMaxLength(2000);

            builder.Property(v => v.Location)
                .HasMaxLength(200);

            builder.Property(v => v.RequiredExperienceYears)
                .IsRequired();

            builder.Property(v => v.EducationRequirement)
                .HasMaxLength(500);

            builder.Property(v => v.Status)
                .IsRequired();

            builder.Property(v => v.CreatedAt)
                .IsRequired();

            builder.Property(v => v.UpdatedAt)
                .IsRequired();

            builder.HasIndex(v => v.EmployerId);
        }
    }
}