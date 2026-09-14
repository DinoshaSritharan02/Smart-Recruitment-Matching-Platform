namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class JobSeekerProfile
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string ProfessionalSummary { get; set; } = string.Empty;

    public ICollection<JobSeekerSkill> JobSeekerSkills { get; set; }
    = new List<JobSeekerSkill>();

    public ICollection<Education> Educations { get; set; } = new List<Education>();

    public ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public CvMetadata? CvMetadata { get; set; }
}