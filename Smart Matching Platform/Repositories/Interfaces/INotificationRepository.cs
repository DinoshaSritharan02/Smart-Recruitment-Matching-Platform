using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Notification>> GetUnreadAsync(Guid userId);

    Task<Notification?> GetByIdAsync(int id);

    Task AddAsync(Notification notification);

    Task UpdateAsync(Notification notification);

    Task DeleteAsync(Notification notification);

    Task SaveChangesAsync();
}