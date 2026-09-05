using SmartRecruitmentMatchingPlatform.API.Enums;

namespace SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;

public class ContactRequestDto
{
    public int Id { get; set; }

    public string EmployerName { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public ContactRequestStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}