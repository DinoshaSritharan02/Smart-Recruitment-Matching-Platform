using Smart_Matching_Platform.Enums;

namespace Smart_Matching_Platform.Models.DTOs.Application
{
    public class ApplicationResponseDto
    {
        public int Id { get; set; }
        public int JobSeekerId { get; set; }
        public int VacancyId { get; set; }
        public ApplicationStatus Status { get; set; }
        public decimal? MatchScore { get; set; }
        public DateTime AppliedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}