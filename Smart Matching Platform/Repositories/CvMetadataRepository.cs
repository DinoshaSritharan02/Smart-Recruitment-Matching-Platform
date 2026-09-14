using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories;

public class CvMetadataRepository : ICvMetadataRepository
{
    private readonly ApplicationDbContext _context;

    public CvMetadataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CvMetadata?> GetByProfileIdAsync(Guid profileId)
    {
        return await _context.CvMetadatas
            .FirstOrDefaultAsync(x => x.JobSeekerProfileId == profileId);
    }

    public async Task AddAsync(CvMetadata metadata)
    {
        await _context.CvMetadatas.AddAsync(metadata);
    }

    public Task UpdateAsync(CvMetadata metadata)
    {
        _context.CvMetadatas.Update(metadata);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}