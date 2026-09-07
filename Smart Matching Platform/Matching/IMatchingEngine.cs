using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Matching
{
    public interface IMatchingEngine
    {
        MatchingResult CalculateMatch(
            JobSeekerProfile jobSeeker,
            Vacancy vacancy);
    }
}