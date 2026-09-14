using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Data;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vacancy?> GetByIdAsync(int id)
        {
            return await _context.Set<Vacancy>()
                .Include(v => v.VacancySkills)
                .ThenInclude(vs => vs.Skill)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Vacancy>> GetByEmployerIdAsync(int employerId)
        {
            return await _context.Set<Vacancy>()
                .Include(v => v.VacancySkills)
                .ThenInclude(vs => vs.Skill)
                .Where(v => v.EmployerId == employerId)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Vacancy>> SearchAsync(
            string? keyword,
            string? location,
            int? minExperienceYears,
            int? maxExperienceYears,
            int? skillId)
        {
            var query = _context.Set<Vacancy>()
                .Include(v => v.VacancySkills)
                .ThenInclude(vs => vs.Skill)
                .Where(v => v.Status == VacancyStatus.Open)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(v =>
                    v.Title.Contains(keyword) ||
                    (v.Description != null &&
                     v.Description.Contains(keyword)));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(v =>
                    v.Location != null &&
                    v.Location.Contains(location));
            }

            if (minExperienceYears.HasValue)
            {
                query = query.Where(v =>
                    v.RequiredExperienceYears >= minExperienceYears.Value);
            }

            if (maxExperienceYears.HasValue)
            {
                query = query.Where(v =>
                    v.RequiredExperienceYears <= maxExperienceYears.Value);
            }

            if (skillId.HasValue)
            {
                query = query.Where(v =>
                    v.VacancySkills.Any(vs =>
                        vs.SkillId == skillId.Value));
            }

            return await query
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(Vacancy vacancy)
        {
            await _context.Set<Vacancy>().AddAsync(vacancy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            _context.Set<Vacancy>().Update(vacancy);
            await _context.SaveChangesAsync();
        }
    }
}