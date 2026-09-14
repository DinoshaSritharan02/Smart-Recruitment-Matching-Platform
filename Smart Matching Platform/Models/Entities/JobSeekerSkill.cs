namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class JobSeekerSkill
{
    public Guid Id { get; set; }

    public Guid JobSeekerProfileId { get; set; }

    public int SkillId { get; set; }

    public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

    public Skill Skill { get; set; } = null!;
}