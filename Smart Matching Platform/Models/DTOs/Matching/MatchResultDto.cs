namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Matching;

public class MatchResultDto
{
    public int VacancyId { get; set; }

    public string JobTitle { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public int MatchPercentage { get; set; }
    public int SkillScore { get; set; }

    public int ExperienceScore { get; set; }

    public int EducationScore { get; set; }

    public int LocationScore { get; set; }

    public List<string> MatchingSkills { get; set; } = new();

    public List<string> MissingSkills { get; set; } = new();
}