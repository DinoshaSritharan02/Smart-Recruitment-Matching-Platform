using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Data.Configurations
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserId)
                   .IsRequired();

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.CompanyDescription)
                .HasMaxLength(1000);

            builder.Property(e => e.Industry)
                .HasMaxLength(100);

            builder.Property(e => e.CompanyLocation)
                .HasMaxLength(200);

            builder.Property(e => e.Website)
                .HasMaxLength(500);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired();
        }
    }
}