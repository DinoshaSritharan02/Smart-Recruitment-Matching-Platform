using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Skill;

namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

public class JobSeekerProfileDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string ProfessionalSummary { get; set; } = string.Empty;

    public List<SkillResponseDto> Skills { get; set; } = new();

    public List<EducationDto> Educations { get; set; } = new();

    public List<ExperienceDto> Experiences { get; set; } = new();
}