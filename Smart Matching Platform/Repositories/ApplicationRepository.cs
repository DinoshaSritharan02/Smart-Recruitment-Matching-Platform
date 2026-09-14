using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Application?> GetByIdAsync(int id)
        {
            return await _context.Set<Application>()
                .Include(a => a.Vacancy)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Application>> GetByVacancyIdAsync(int vacancyId)
        {
            return await _context.Set<Application>()
                .Include(a => a.Vacancy)
                .Where(a => a.VacancyId == vacancyId)
                .OrderByDescending(a => a.MatchScore)
                .ToListAsync();
        }

        public async Task<List<Application>> GetByJobSeekerProfileIdAsync(Guid jobSeekerProfileId)
        {
            return await _context.Set<Application>()
                .Include(a => a.Vacancy)
                    .ThenInclude(v => v.Employer)
                .Where(a => a.JobSeekerProfileId == jobSeekerProfileId)
                .OrderByDescending(a => a.AppliedAt)
                .ToListAsync();
        }

        public async Task AddAsync(Application application)
        {
            await _context.Set<Application>().AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Application application)
        {
            _context.Set<Application>().Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid jobSeekerProfileId, int vacancyId)
        {
            return await _context.Set<Application>()
                .AnyAsync(a =>
                    a.JobSeekerProfileId == jobSeekerProfileId &&
                    a.VacancyId == vacancyId);
        }
    }
}