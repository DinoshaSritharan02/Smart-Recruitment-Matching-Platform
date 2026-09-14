using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200);

        builder.Property(x => x.JobTitle)
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(3000);

        builder.HasOne(x => x.JobSeekerProfile)
            .WithMany(x => x.Experiences)
            .HasForeignKey(x => x.JobSeekerProfileId);
    }
}