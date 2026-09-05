using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations;

public class JobSeekerSkillConfiguration : IEntityTypeConfiguration<JobSeekerSkill>
{
    public void Configure(EntityTypeBuilder<JobSeekerSkill> builder)
    {
        builder.ToTable("JobSeekerSkills");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SkillName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => new
        {
            x.JobSeekerProfileId,
            x.SkillName
        }).IsUnique();

        builder.HasOne(x => x.JobSeekerProfile)
            .WithMany(x => x.Skills)
            .HasForeignKey(x => x.JobSeekerProfileId);
    }
}