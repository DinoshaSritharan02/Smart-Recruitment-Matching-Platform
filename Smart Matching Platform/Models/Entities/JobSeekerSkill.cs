namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class JobSeekerSkill
{
    public Guid Id { get; set; }

    public Guid JobSeekerProfileId { get; set; }

    public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

    public string SkillName { get; set; } = string.Empty;
}