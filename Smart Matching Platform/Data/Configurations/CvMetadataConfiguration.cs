using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations;

public class CvMetadataConfiguration : IEntityTypeConfiguration<CvMetadata>
{
    public void Configure(EntityTypeBuilder<CvMetadata> builder)
    {
        builder.ToTable("CvMetadatas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.OriginalFileName)
            .HasMaxLength(255);

        builder.Property(x => x.StoredFileName)
            .HasMaxLength(255);

        builder.Property(x => x.ContentType)
            .HasMaxLength(100);

        builder.HasOne(x => x.JobSeekerProfile)
            .WithOne(x => x.CvMetadata)
            .HasForeignKey<CvMetadata>(x => x.JobSeekerProfileId);
    }
}