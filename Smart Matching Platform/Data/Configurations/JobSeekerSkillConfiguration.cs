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

        builder.Property(x => x.SkillId)
            .IsRequired();

        builder.HasOne(x => x.JobSeekerProfile)
            .WithMany(x => x.JobSeekerSkills)
            .HasForeignKey(x => x.JobSeekerProfileId);

        builder.HasOne(x => x.Skill)
            .WithMany(x => x.JobSeekerSkills)
            .HasForeignKey(x => x.SkillId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.JobSeekerProfileId,
            x.SkillId
        }).IsUnique();
    }
}