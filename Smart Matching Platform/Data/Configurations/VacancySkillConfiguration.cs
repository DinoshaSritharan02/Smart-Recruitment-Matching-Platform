using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Data.Configurations
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
                .WithMany()
                .HasForeignKey(vs => vs.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}