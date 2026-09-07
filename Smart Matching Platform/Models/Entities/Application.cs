using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Models.Entities
{
    public class Application
    {
        public int Id { get; set; }

        public Guid JobSeekerProfileId { get; set; }

        public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

        public int VacancyId { get; set; }

        public ApplicationStatus Status { get; set; }

        public decimal? MatchScore { get; set; }

        public DateTime AppliedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Vacancy Vacancy { get; set; } = null!;
    }
}