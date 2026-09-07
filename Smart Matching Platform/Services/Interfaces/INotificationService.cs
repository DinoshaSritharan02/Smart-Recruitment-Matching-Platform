using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;

namespace SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetNotificationsAsync(Guid userId);

    Task CreateNotificationAsync(CreateNotificationDto dto);

    Task MarkAsReadAsync(int notificationId);

    Task DeleteNotificationAsync(int notificationId);
}