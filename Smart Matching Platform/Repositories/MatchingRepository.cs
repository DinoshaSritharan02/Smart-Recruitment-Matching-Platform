using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Matching;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Matching;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public class MatchingRepository : IMatchingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMatchingEngine _matchingEngine;

        public MatchingRepository(
            ApplicationDbContext context,
            IMatchingEngine matchingEngine)
        {
            _context = context;
            _matchingEngine = matchingEngine;
        }

        public async Task<List<MatchResultDto>> GetMatchesAsync(Guid userId)
        {
            var jobSeeker = await _context.JobSeekerProfiles
                .Include(j => j.JobSeekerSkills)
    .ThenInclude(js => js.Skill)
.Include(j => j.Experiences)
.Include(j => j.Educations)
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

                var result = _matchingEngine.CalculateMatch(jobSeeker, vacancy);

                results.Add(new MatchResultDto
                {
                    VacancyId = vacancy.Id,
                    JobTitle = vacancy.Title,
                    CompanyName = vacancy.Employer.CompanyName,
                    MatchPercentage = result.Score,
                    SkillScore = result.SkillScore,
                    ExperienceScore = result.ExperienceScore,
                    EducationScore = result.EducationScore,
                    LocationScore = result.LocationScore,
                    MatchingSkills = result.MatchingSkills,
                    MissingSkills = result.MissingSkills
                });
            }

            return results
                .OrderByDescending(r => r.MatchPercentage)
                .ToList();
        }
        public async Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(int vacancyId)
        {
            var vacancy = await _context.Vacancies
                .Include(v => v.VacancySkills)
                    .ThenInclude(vs => vs.Skill)
                .FirstOrDefaultAsync(v => v.Id == vacancyId);

            if (vacancy == null)
                return new List<RankedApplicantResponseDto>();

            var applications = await _context.Applications
                .Where(a => a.VacancyId == vacancyId)
                .Include(a => a.JobSeekerProfile)
                    .ThenInclude(j => j.User)
                .Include(a => a.JobSeekerProfile)
                    .ThenInclude(j => j.JobSeekerSkills)
                        .ThenInclude(js => js.Skill)
                .Include(a => a.JobSeekerProfile)
                    .ThenInclude(j => j.Experiences)
                .Include(a => a.JobSeekerProfile)
                    .ThenInclude(j => j.Educations)
                .ToListAsync();

            var rankedApplicants = new List<RankedApplicantResponseDto>();

            foreach (var application in applications)
            {
                var result = _matchingEngine.CalculateMatch(
                    application.JobSeekerProfile,
                    vacancy);

                rankedApplicants.Add(new RankedApplicantResponseDto
                {
                    ApplicationId = application.Id,
                    JobSeekerProfileId = application.JobSeekerProfileId,
                    CandidateName = $"{application.JobSeekerProfile.User.FirstName} {application.JobSeekerProfile.User.LastName}",
                    MatchScore = result.Score,
                    MissingSkills = result.MissingSkills,
                    Status = application.Status.ToString(),
                    AppliedAt = application.AppliedAt
                });
            }

            return rankedApplicants
                .OrderByDescending(a => a.MatchScore)
                .ToList();
        }
    }
}