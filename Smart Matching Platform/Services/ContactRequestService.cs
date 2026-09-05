using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;
using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Services.Implementations;

public class ContactRequestService : IContactRequestService
{
    private readonly IContactRequestRepository _repository;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public ContactRequestService(
        IContactRequestRepository repository,
        INotificationService notificationService,
        IMapper mapper)
    {
        _repository = repository;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContactRequestDto>> GetRequestsAsync(int jobSeekerProfileId)
    {
        var requests = await _repository.GetForJobSeekerAsync(jobSeekerProfileId);

        return _mapper.Map<IEnumerable<ContactRequestDto>>(requests);
    }

    public async Task UpdateStatusAsync(int requestId, UpdateContactRequestStatusDto dto)
    {
        var request = await _repository.GetByIdAsync(requestId);

        if (request == null)
            throw new Exception("Contact request not found.");

        request.Status = dto.Status;
        request.RespondedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(request);
        await _repository.SaveChangesAsync();

        await _notificationService.CreateNotificationAsync(new CreateNotificationDto
        {
            UserId = request.Employer.UserId,
            Title = "Contact Request",
            Message = dto.Status == ContactRequestStatus.Accepted
                ? "Your contact request has been accepted."
                : "Your contact request has been declined."
        });
    }
}