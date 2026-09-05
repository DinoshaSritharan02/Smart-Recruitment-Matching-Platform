namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class Education
{
    public Guid Id { get; set; }

    public Guid JobSeekerProfileId { get; set; }

    public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

    public string Institution { get; set; } = string.Empty;

    public string Degree { get; set; } = string.Empty;

    public string FieldOfStudy { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}