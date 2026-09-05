namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

public class UpdateJobSeekerProfileDto
{
    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string ProfessionalSummary { get; set; } = string.Empty;
}