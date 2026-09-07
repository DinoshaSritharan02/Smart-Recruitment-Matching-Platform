using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Matching
{
    public class MatchingEngine : IMatchingEngine
    {
        public MatchingResult CalculateMatch(
            JobSeekerProfile jobSeeker,
            Vacancy vacancy)
        {
            var matchingSkills = GetMatchingSkills(jobSeeker, vacancy);
            var missingSkills = GetMissingSkills(jobSeeker, vacancy);

            int skillScore = CalculateSkillScore(
                matchingSkills.Count,
                vacancy.VacancySkills.Count);

            int experienceScore = CalculateExperienceScore(
                jobSeeker,
                vacancy);

            int educationScore = CalculateEducationScore(
                jobSeeker,
                vacancy);

            int locationScore = CalculateLocationScore(
                jobSeeker,
                vacancy);

            return new MatchingResult
            {
                Score = skillScore
          + experienceScore
          + educationScore
          + locationScore,

                SkillScore = skillScore,
                ExperienceScore = experienceScore,
                EducationScore = educationScore,
                LocationScore = locationScore,

                MatchingSkills = matchingSkills,
                MissingSkills = missingSkills
            };
        }

        private List<string> GetMatchingSkills(JobSeekerProfile seeker, Vacancy vacancy)
        {
            var seekerSkills = seeker.JobSeekerSkills
                .Select(s => s.Skill.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return vacancy.VacancySkills
                .Where(vs => seekerSkills.Contains(vs.Skill.Name))
                .Select(vs => vs.Skill.Name)
                .ToList();
        }

        private List<string> GetMissingSkills(JobSeekerProfile seeker, Vacancy vacancy)
        {
            var seekerSkills = seeker.JobSeekerSkills
                .Select(s => s.Skill.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return vacancy.VacancySkills
                .Where(vs => !seekerSkills.Contains(vs.Skill.Name))
                .Select(vs => vs.Skill.Name)
                .ToList();
        }
        private int CalculateSkillScore(int matchingSkills, int requiredSkills)
        {
            if (requiredSkills == 0)
                return 0;

            return (int)Math.Round(
                (double)matchingSkills / requiredSkills * MatchingWeights.Skills);
        }

        private int CalculateExperienceScore(JobSeekerProfile seeker, Vacancy vacancy)
        {
            double candidateYears = seeker.Experiences?.Sum(e =>
            {
                var endDate = e.EndDate ?? DateTime.UtcNow;

                return (endDate - e.StartDate).TotalDays / 365.25;
            }) ?? 0;

            int requiredYears = vacancy.RequiredExperienceYears;

            if (requiredYears <= 0)
                return MatchingWeights.Experience;

            var ratio = Math.Min(candidateYears / requiredYears, 1.0);

            return (int)Math.Round(ratio * MatchingWeights.Experience);
        }
        private int CalculateEducationScore(JobSeekerProfile seeker, Vacancy vacancy)
        {
            if (string.IsNullOrWhiteSpace(vacancy.EducationRequirement))
                return MatchingWeights.Education;

            var required = vacancy.EducationRequirement.Trim().ToLower();

            bool matched = seeker.Educations.Any(e =>
                !string.IsNullOrWhiteSpace(e.Degree) &&
                e.Degree.Trim().ToLower().Contains(required));

            return matched ? MatchingWeights.Education : 0;
        }
        private int CalculateLocationScore(JobSeekerProfile seeker, Vacancy vacancy)
        {
            if (string.IsNullOrWhiteSpace(vacancy.Location))
                return MatchingWeights.Location;

            var vacancyLocation = vacancy.Location.Trim();

            if (!string.IsNullOrWhiteSpace(seeker.City) &&
                seeker.City.Equals(vacancyLocation, StringComparison.OrdinalIgnoreCase))
            {
                return MatchingWeights.Location;
            }

            if (!string.IsNullOrWhiteSpace(seeker.Country) &&
                seeker.Country.Equals(vacancyLocation, StringComparison.OrdinalIgnoreCase))
            {
                return MatchingWeights.Location;
            }

            return 0;
        }
    }
}