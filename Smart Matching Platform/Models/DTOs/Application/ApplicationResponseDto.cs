using SmartRecruitmentMatchingPlatform.API.Enums;

namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application
{
    public class ApplicationResponseDto
    {
        public int Id { get; set; }
        public Guid JobSeekerProfileId { get; set; }
        public int VacancyId { get; set; }
        public ApplicationStatus Status { get; set; }
        public decimal? MatchScore { get; set; }
        public DateTime AppliedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}