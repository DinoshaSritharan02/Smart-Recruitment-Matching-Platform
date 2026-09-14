using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations
{
    public class VacancySkillConfiguration
        : IEntityTypeConfiguration<VacancySkill>
    {
        public void Configure(EntityTypeBuilder<VacancySkill> builder)
        {
            builder.HasKey(vs => new
            {
                vs.VacancyId,
                vs.SkillId
            });

            builder.HasOne(vs => vs.Vacancy)
                .WithMany(v => v.VacancySkills)
                .HasForeignKey(vs => vs.VacancyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vs => vs.Skill)
     .WithMany(s => s.VacancySkills)
     .HasForeignKey(vs => vs.SkillId)
     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}