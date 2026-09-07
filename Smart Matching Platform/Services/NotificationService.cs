using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Services.Implementations;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;
    private readonly IMapper _mapper;

    public NotificationService(
        INotificationRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationDto>> GetNotificationsAsync(Guid userId)
    {
        var notifications = await _repository.GetByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
    }

    public async Task<IEnumerable<NotificationDto>> GetUnreadAsync(Guid userId)
    {
        var notifications = await _repository.GetUnreadAsync(userId);
        return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
    }

    public async Task CreateNotificationAsync(CreateNotificationDto dto)
    {
        var notification = _mapper.Map<Notification>(dto);

        await _repository.AddAsync(notification);

        await _repository.SaveChangesAsync();
    }

    public async Task MarkAsReadAsync(int notificationId)
    {
        var notification = await _repository.GetByIdAsync(notificationId);

        if (notification == null)
            throw new Exception("Notification not found.");

        notification.IsRead = true;

        await _repository.UpdateAsync(notification);

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteNotificationAsync(int notificationId)
    {
        var notification = await _repository.GetByIdAsync(notificationId);

        if (notification == null)
            throw new Exception("Notification not found.");

        await _repository.DeleteAsync(notification);

        await _repository.SaveChangesAsync();
    }
}