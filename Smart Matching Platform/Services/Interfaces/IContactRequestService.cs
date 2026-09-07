using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.ContactRequest;

public interface IContactRequestService
{
    Task<IEnumerable<ContactRequestDto>> GetRequestsAsync(Guid jobSeekerProfileId);

    Task UpdateStatusAsync(
    int requestId,
    Guid jobSeekerUserId,
    UpdateContactRequestStatusDto dto);

    Task<ContactRequestDto> CreateAsync(
        int employerId,
        CreateContactRequestDto dto);
}