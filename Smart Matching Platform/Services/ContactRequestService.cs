using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;
using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.ContactRequest;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories.Implementations;
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

    public async Task<IEnumerable<ContactRequestDto>> GetRequestsAsync(Guid jobSeekerProfileId)
    {
        var requests = await _repository.GetForJobSeekerAsync(jobSeekerProfileId);

        return _mapper.Map<IEnumerable<ContactRequestDto>>(requests);
    }

    public async Task UpdateStatusAsync(
     int requestId,
     Guid jobSeekerUserId,
     UpdateContactRequestStatusDto dto)
    {
        var request = await _repository.GetByIdAsync(requestId);

        if (request == null)
            throw new Exception("Contact request not found.");

        // Verify ownership
        if (request.JobSeekerProfile.UserId != jobSeekerUserId)
            throw new UnauthorizedAccessException(
                "You are not allowed to update this contact request.");

        // Only pending requests can be updated
        if (request.Status != ContactRequestStatus.Pending)
            throw new InvalidOperationException(
                "Only pending contact requests can be updated.");

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
    public async Task<ContactRequestDto> CreateAsync(
    int employerId,
    CreateContactRequestDto dto)
    {
        var exists = await _repository.ExistsPendingRequestAsync(
            employerId,
            dto.JobSeekerProfileId);

        if (exists)
            throw new InvalidOperationException(
                "A pending contact request already exists.");

        var request = new ContactRequest
        {
            EmployerId = employerId,
            JobSeekerProfileId = dto.JobSeekerProfileId,
            Message = dto.Message,
            Status = ContactRequestStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(request);
        await _repository.SaveChangesAsync();

        return _mapper.Map<ContactRequestDto>(request);
    }
}