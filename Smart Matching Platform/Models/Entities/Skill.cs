using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigation property
    public ICollection<JobSeekerSkill> JobSeekerSkills { get; set; }
        = new List<JobSeekerSkill>();

    public ICollection<VacancySkill> VacancySkills { get; set; }
        = new List<VacancySkill>();
}