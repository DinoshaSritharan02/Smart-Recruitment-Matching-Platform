using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using Smart_Matching_Platform.Models.Entities;
using Smart_Matching_Platform.Repositories.Interfaces;

namespace Smart_Matching_Platform.Repositories
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

        public async Task<List<Application>> GetByJobSeekerIdAsync(int jobSeekerId)
        {
            return await _context.Set<Application>()
                .Include(a => a.Vacancy)
                .Where(a => a.JobSeekerId == jobSeekerId)
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

        public async Task<bool> ExistsAsync(int jobSeekerId, int vacancyId)
        {
            return await _context.Set<Application>()
                .AnyAsync(a =>
                    a.JobSeekerId == jobSeekerId &&
                    a.VacancyId == vacancyId);
        }
    }
}