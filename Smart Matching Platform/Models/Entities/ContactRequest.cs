using SmartRecruitmentMatchingPlatform.API.Enums;
using Smart_Matching_Platform.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class ContactRequest
{
    public int Id { get; set; }

    public int EmployerId { get; set; }

    public Employer Employer { get; set; } = null!;

    public int JobSeekerProfileId { get; set; }

    public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

    public string Message { get; set; } = string.Empty;

    public ContactRequestStatus Status { get; set; } = ContactRequestStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? RespondedAt { get; set; }
}