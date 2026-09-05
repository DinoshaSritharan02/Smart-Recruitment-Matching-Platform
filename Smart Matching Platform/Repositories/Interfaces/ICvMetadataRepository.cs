using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories;

public interface ICvMetadataRepository
{
    Task<CvMetadata?> GetByProfileIdAsync(Guid profileId);

    Task AddAsync(CvMetadata metadata);

    Task UpdateAsync(CvMetadata metadata);

    Task SaveChangesAsync();
}