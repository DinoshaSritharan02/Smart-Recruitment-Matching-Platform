using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;

namespace SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

public interface IContactRequestService
{
    Task<IEnumerable<ContactRequestDto>> GetRequestsAsync(Guid jobSeekerProfileId);

    Task UpdateStatusAsync(int requestId, UpdateContactRequestStatusDto dto);
}