using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Implementations;

public class ContactRequestRepository : IContactRequestRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ContactRequest?> GetByIdAsync(int id)
    {
        return await _context.ContactRequests
            .Include(c => c.Employer)
            .Include(c => c.JobSeekerProfile)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<ContactRequest>> GetForJobSeekerAsync(Guid jobSeekerProfileId)
    {
        return await _context.ContactRequests
            .Include(c => c.Employer)
            .Where(c => c.JobSeekerProfileId == jobSeekerProfileId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task AddAsync(ContactRequest request)
    {
        await _context.ContactRequests.AddAsync(request);
    }

    public Task UpdateAsync(ContactRequest request)
    {
        _context.ContactRequests.Update(request);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<bool> ExistsPendingRequestAsync(
    int employerId,
    Guid jobSeekerProfileId)
    {
        return await _context.ContactRequests.AnyAsync(x =>
            x.EmployerId == employerId &&
            x.JobSeekerProfileId == jobSeekerProfileId &&
            x.Status == ContactRequestStatus.Pending);
    }
}