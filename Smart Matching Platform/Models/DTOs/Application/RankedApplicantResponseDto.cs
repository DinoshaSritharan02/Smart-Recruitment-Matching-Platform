namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application
{
    public class RankedApplicantResponseDto
    {
        public int ApplicationId { get; set; }

        public Guid JobSeekerProfileId { get; set; }

        public decimal? MatchScore { get; set; }

        public List<string> MissingSkills { get; set; } = new();

        public string Status { get; set; } = string.Empty;

        public DateTime AppliedAt { get; set; }
    }
}