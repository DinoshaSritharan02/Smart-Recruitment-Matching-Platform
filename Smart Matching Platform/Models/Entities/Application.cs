using Smart_Matching_Platform.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace Smart_Matching_Platform.Models.Entities
{
    public class Application
    {
        public int Id { get; set; }

        public int JobSeekerId { get; set; }

        public int VacancyId { get; set; }

        public ApplicationStatus Status { get; set; }

        public decimal? MatchScore { get; set; }

        public DateTime AppliedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Vacancy Vacancy { get; set; } = null!;
    }
}