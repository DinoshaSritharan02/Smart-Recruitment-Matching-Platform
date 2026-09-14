namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

public class CreateExperienceDto
{
    public string CompanyName { get; set; } = string.Empty;

    public string JobTitle { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}