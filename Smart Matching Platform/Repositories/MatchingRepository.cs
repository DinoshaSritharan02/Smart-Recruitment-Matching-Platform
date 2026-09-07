using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Matching;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public class MatchingRepository : IMatchingRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MatchResultDto>> GetMatchesAsync(Guid userId)
        {
            var jobSeeker = await _context.JobSeekerProfiles
                .Include(j => j.JobSeekerSkills)
                    .ThenInclude(js => js.Skill)
                .FirstOrDefaultAsync(j => j.UserId == userId);

            if (jobSeeker == null)
                return new List<MatchResultDto>();

            var seekerSkills = jobSeeker.JobSeekerSkills
                .Select(s => s.Skill.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var vacancies = await _context.Vacancies
    .Where(v => v.Status == VacancyStatus.Open)
    .Include(v => v.Employer)
    .Include(v => v.VacancySkills)
        .ThenInclude(vs => vs.Skill)
    .ToListAsync();

            var results = new List<MatchResultDto>();

            foreach (var vacancy in vacancies)
            {
                var requiredSkills = vacancy.VacancySkills
                    .Select(vs => vs.Skill.Name)
                    .ToList();

                if (requiredSkills.Count == 0)
                    continue;

                var matchingSkills = requiredSkills
                    .Where(s => seekerSkills.Contains(s))
                    .ToList();

                var missingSkills = requiredSkills
                    .Except(matchingSkills)
                    .ToList();

               

                results.Add(new MatchResultDto
                {
                    VacancyId = vacancy.Id,
                    JobTitle = vacancy.Title,
                    CompanyName = vacancy.Employer.CompanyName,
                    MatchPercentage = (int)Math.Round(
                        (double)matchingSkills.Count / requiredSkills.Count * 100),

                    MatchingSkills = matchingSkills,
                    MissingSkills = missingSkills
                });
            }

            return results
                .OrderByDescending(r => r.MatchPercentage)
                .ToList();
        }
    }
}