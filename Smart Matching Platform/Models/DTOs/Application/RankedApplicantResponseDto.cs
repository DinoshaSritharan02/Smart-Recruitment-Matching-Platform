namespace Smart_Matching_Platform.Models.DTOs.Application
{
    public class RankedApplicantResponseDto
    {
        public int ApplicationId { get; set; }

        public int JobSeekerId { get; set; }

        public decimal? MatchScore { get; set; }

        public List<string> MissingSkills { get; set; } = new();

        public string Status { get; set; } = string.Empty;

        public DateTime AppliedAt { get; set; }
    }
}