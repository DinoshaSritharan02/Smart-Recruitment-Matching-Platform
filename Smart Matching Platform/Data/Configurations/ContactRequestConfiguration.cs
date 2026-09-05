using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations;

public class ContactRequestConfiguration : IEntityTypeConfiguration<ContactRequest>
{
    public void Configure(EntityTypeBuilder<ContactRequest> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Message)
            .HasMaxLength(500);

        builder.Property(x => x.Status)
            .HasConversion<string>();

        builder.HasOne(x => x.Employer)
            .WithMany()
            .HasForeignKey(x => x.EmployerId);

        builder.HasOne(x => x.JobSeekerProfile)
            .WithMany()
            .HasForeignKey(x => x.JobSeekerProfileId);
    }
}