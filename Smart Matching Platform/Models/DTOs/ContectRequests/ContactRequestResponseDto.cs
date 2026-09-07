namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.ContactRequest;

public class CreateContactRequestDto
{
    public Guid JobSeekerProfileId { get; set; }

    public string? Message { get; set; }
}