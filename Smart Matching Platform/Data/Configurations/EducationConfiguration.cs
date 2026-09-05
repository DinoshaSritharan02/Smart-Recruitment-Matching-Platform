using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Institution)
            .HasMaxLength(200);

        builder.Property(x => x.Degree)
            .HasMaxLength(200);

        builder.Property(x => x.FieldOfStudy)
            .HasMaxLength(200);

        builder.HasOne(x => x.JobSeekerProfile)
            .WithMany(x => x.Educations)
            .HasForeignKey(x => x.JobSeekerProfileId);
    }
}