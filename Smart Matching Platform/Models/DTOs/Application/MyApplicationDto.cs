namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;

public class MyApplicationDto
{
    public int Id { get; set; }

    public int VacancyId { get; set; }

    public string JobTitle { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public decimal? MatchScore { get; set; }

    public DateTime AppliedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}